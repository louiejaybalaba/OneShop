using MainPage.Interface;
using MainPage.Model;
using MainPage.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Presenter
{
    class ViewPendingTransactionsPagePresenter
    {
        ViewPendingTransactionsPageInterface ViewPendingTransactionsPageView;
        ViewPendingTransactionsPageModel mod = new ViewPendingTransactionsPageModel();
        ViewPendingTransactionsPageObject obj = new ViewPendingTransactionsPageObject();
        public ViewPendingTransactionsPagePresenter(ViewPendingTransactionsPageInterface IViewPendingTransactionsPageView)
        {
            ViewPendingTransactionsPageView = IViewPendingTransactionsPageView;
        }

        public void RetrieveProductStatus()
        {
           
            obj.ViewPendingTransactionsPageConnectionString = ViewPendingTransactionsPageView.ViewPendingTransactionsPageConnectionString;

            ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableOfStatus = mod.RetrieveProductStatus(obj);
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageFilterByProductStatusCombo.DataSource = ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableOfStatus;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageFilterByProductStatusCombo.DisplayMember = "Description";
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageFilterByProductStatusCombo.ValueMember = "ProductStatusID";
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageFilterByProductStatusCombo.SelectedIndex = 1;


            ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableUpdateStatus = mod.RetrieveProductStatusUpdate(obj);
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.DataSource = ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableUpdateStatus;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.DisplayMember = "Description";
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.ValueMember = "ProductStatusID";
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.SelectedIndex = -1;


        }

        public void RetrieveAllTransactions()
        {
            int Count = 0;
            obj.ViewPendingTransactionsPageSearchIsCLicked = ViewPendingTransactionsPageView.ViewPendingTransactionsPageSearchIsCLicked;
            obj.ViewPendingTransactionsPageSearchIsCLicked = ViewPendingTransactionsPageView.ViewPendingTransactionsPageSearchIsCLicked;
            obj.ViewPendingTransactionsPageSelectedProductStatusID = ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedProductStatusID;
            obj.ViewPendingTransactionsPageRetailerID = ViewPendingTransactionsPageView.ViewPendingTransactionsPageRetailerID;
            obj.ViewPendingTransactionsPageConnectionString = ViewPendingTransactionsPageView.ViewPendingTransactionsPageConnectionString;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableOfTransactions = mod.RetrieveAllTransactions(obj);
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageListOfTransactions.DataSource = ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableOfTransactions;
            foreach (DataGridViewColumn dg in ViewPendingTransactionsPageView.ViewPendingTransactionsPageListOfTransactions.Columns)
            {
                if (dg.Name.Contains("_"))
                {
                    ViewPendingTransactionsPageView.ViewPendingTransactionsPageListOfTransactions.Columns[Count].Visible = false;

                }
                else
                {
                    ViewPendingTransactionsPageView.ViewPendingTransactionsPageListOfTransactions.Columns[Count].ReadOnly = true;

                }
                Count += 1;
            }
        }

        public void GetShippingAndProductStatus()
        {
            DataRow dr = ViewPendingTransactionsPageView.ViewPendingTransactionsPageDatatableOfTransactions.Rows[ViewPendingTransactionsPageView.ViewPendingTransactionsPageListOfTransactions.CurrentCell.RowIndex];
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow = dr;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageProductManagementIDTxB.Text = dr["_ProductManagementID"].ToString();
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.SelectedValue = Int32.Parse(dr["_ProductStatusID"].ToString());
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingID = Int32.Parse(dr["_ShippingID"].ToString());         
                try
            {
                ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingDate.Value = DateTime.Parse(dr["_ShippingDate"].ToString());
                ViewPendingTransactionsPageView.ViewPendingTransactionsPageDeliveryDate.Value = DateTime.Parse(dr["_DeliveryDate"].ToString());
                ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingIdentifier.Visible = false;
            }

            catch
            {

                ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingIdentifier.Visible = true;
                ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingDate.Value = DateTime.Now;
                ViewPendingTransactionsPageView.ViewPendingTransactionsPageDeliveryDate.Value = DateTime.Now;
            }
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusIDBtn.Enabled = true;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateShippingInfoBtn.Enabled = true;


        }

        public void UpdateShippingInfo()
        {

            obj.ViewPendingTransactionsPageProductManagementID = Int32.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageProductManagementIDTxB.Text.ToString());
            obj.ViewPendingTransactionsPageShippingDate = ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingDate.Value;
            obj.ViewPendingTransactionsPageDeilveryDate = ViewPendingTransactionsPageView.ViewPendingTransactionsPageDeliveryDate.Value;
            obj.ViewPendingTransactionsPageShippingID = ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingID;
            obj.ViewPendingTransactionsPageConnectionString = ViewPendingTransactionsPageView.ViewPendingTransactionsPageConnectionString;
            obj.ViewPendingTransactionsPageRetailerID = ViewPendingTransactionsPageView.ViewPendingTransactionsPageRetailerID;

            if (CheckIfCompletedOrCanceled()==true && mod.UpdateShippingInfo(obj) == true)
            {

                ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.SelectedValue = 3;

            };

        }

        public bool CheckIfCompletedOrCanceled()
        {
         
            if (Int32.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_ProductStatusID"].ToString()) == 4 ||
                Int32.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_ProductStatusID"].ToString()) == 5
              )
            {
                MessageBox.Show("Cannot Update Anymore if transaction is already completed or Canceled");
                return false;
            }
            else
            {

                return true;
            }

        }
        public void UpdateProductStatus()
        {
            obj.ViewPendingTransactionsPageCustomerID = int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_CustomerID"].ToString());
            obj.ViewPendingTransactionsPageConnectionString = ViewPendingTransactionsPageView.ViewPendingTransactionsPageConnectionString;
            obj.ViewPendingTransactionsPageProductManagementID = Int32.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageProductManagementIDTxB.Text.ToString());
            obj.ViewPendingTransactionsPageSelectedProductStatusID = int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.SelectedValue.ToString());
            obj.ViewPendingTransactionsPageRetailerID = ViewPendingTransactionsPageView.ViewPendingTransactionsPageRetailerID;
            obj.ViewPendingTransactionsPageUpdateProfits = decimal.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["Total"].ToString());
            obj.ViewPendingTransactionsPageCustomerID = int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_CustomerID"].ToString());
            obj.ViewPendingTransactionsPageCustomerNumberOfPurchased = 
                int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["NumberOfPurchased"].ToString()) 
              + int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_CustomerNumberOfPurchased"].ToString());
            obj.ViewPendingTransactionsPageTotalPrice = decimal.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["Total"].ToString());
            obj.ViewPendingTransactionsPageProductID = int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_ProductID"].ToString());
            if (CheckIfCompletedOrCanceled() == true)
            {
                ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusID = int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedDatarow["_ProductStatusID"].ToString());
              

                if (Int32.Parse( ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusCombo.SelectedValue.ToString()) == 4 &&
                    ViewPendingTransactionsPageView.ViewPendingTransactionsPageUpdateProductStatusID ==2
                    )
                {

                    MessageBox.Show("Please Update Shipping First");

                }
                else
                {
                    mod.UpdateProductStatus(obj);
                }
                
            }
      
            

        }


    }
}
