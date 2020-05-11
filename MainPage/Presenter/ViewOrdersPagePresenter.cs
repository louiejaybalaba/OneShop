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
    class ViewOrdersPagePresenter
    {
        ViewOrdersPageInterface ViewOrdersPageView;
        ViewOrdersPageModel mod = new ViewOrdersPageModel();
        ViewOrdersPageObject obj = new ViewOrdersPageObject();
        public ViewOrdersPagePresenter(ViewOrdersPageInterface IViewOrdersPageView)
        {
            ViewOrdersPageView = IViewOrdersPageView;
        }

        public void ViewOrdersLoadProductStatus()
        {
            obj.ViewOrdersPageConnectionString = ViewOrdersPageView.ViewOrdersPageConnectionString;
            ViewOrdersPageView.ViewOrdersPageDatatableOfProductStatus = mod.LoadAlProductStatus(obj);
            ViewOrdersPageView.ViewOrdersPageFilterByProductStatus.DataSource = ViewOrdersPageView.ViewOrdersPageDatatableOfProductStatus;
            ViewOrdersPageView.ViewOrdersPageFilterByProductStatus.DisplayMember = "Description";
            ViewOrdersPageView.ViewOrdersPageFilterByProductStatus.ValueMember = "ProductStatusID";
            ViewOrdersPageView.ViewOrdersPageFilterByProductStatus.SelectedIndex = 1;
        }

        public void LoadOrdersPage()
        {
            obj.ViewOrdersPageSearchButtonIsClicked = ViewOrdersPageView.ViewOrdersPageSearchIsClicked;
            obj.ViewOrdersPageConnectionString = ViewOrdersPageView.ViewOrdersPageConnectionString;
            obj.ViewOrdersPageCustomerID = ViewOrdersPageView.ViewOrdersPageCustomerID;
            try
            {
                obj.ViewOrdersPageSelectedStatus = int.Parse(ViewOrdersPageView.ViewOrdersPageFilterByProductStatus.SelectedValue.ToString());
            }
            catch
            {
                obj.ViewOrdersPageSelectedStatus = 1;
            }
            
            ViewOrdersPageView.ViewOrdersPageDatatableOfOrders= mod.LoadAllMyOrders(obj);
            AddCancelableColumn();
            BindDataSourceAndHideColumns();
          

        }
        public void BindDataSourceAndHideColumns()
        {
            ViewOrdersPageView.ViewOrdersPageListOfOrders.DataSource = ViewOrdersPageView.ViewOrdersPageDatatableOfOrders;
            int count = 0;
            foreach (DataGridViewColumn dg in ViewOrdersPageView.ViewOrdersPageListOfOrders.Columns)
            {
                if (dg.Name.Contains("_"))
                {
                    ViewOrdersPageView.ViewOrdersPageListOfOrders.Columns[count].Visible = false;

                }
                count += 1;
            }
        }

        public void  AddCancelableColumn()
        {
            ViewOrdersPageView.ViewOrdersPageDatatableOfOrders.Columns.Add("Cancelable", typeof(String));
            foreach (DataRow dr in ViewOrdersPageView.ViewOrdersPageDatatableOfOrders.Rows)
            {
                FetchDateTimeSpan(dr);
            }
           
                

        }

        public void FetchDateTimeSpan(DataRow dr)
        {
            DateTime CurrentDateTime = DateTime.Now;

            DateTime FetchDate = Convert.ToDateTime(dr["TimePurchased"].ToString());
            TimeSpan span = CurrentDateTime.Subtract(FetchDate);
            ViewOrdersPageView.ViewOrdersPageGetTimeDifference = span;
            if (span.TotalHours > 6 || (Int32.Parse(dr["_ProductStatusID"].ToString()) == 4 || Int32.Parse(dr["_ProductStatusID"].ToString()) == 5))
            {
                dr["Cancelable"] = "No";

            }
            else
            {
                dr["Cancelable"] = "Yes";
            }
        }
        
public void CancelOrder()
        {
           
            obj.ViewOrdersPageConnectionString = ViewOrdersPageView.ViewOrdersPageConnectionString;
            obj.ViewOrdersPageCustomerID = ViewOrdersPageView.ViewOrdersPageCustomerID;
            obj.ViewOrdersPageProductManagementID = int.Parse(ViewOrdersPageView.ViewPOrdersPageProductManagement.Text.ToString());
            int CurrentStatusID = int.Parse( ViewOrdersPageView.ViewOrdersPageSelectedDatarow["_ProductStatusID"].ToString());
            obj.ViewOrdersPageProductID = int.Parse(ViewOrdersPageView.ViewOrdersPageSelectedDatarow["_ProductID"].ToString());  
            obj.ViewOrdersPagerNumberOfPurchased = int.Parse(ViewOrdersPageView.ViewOrdersPageSelectedDatarow["NumberOfPurchased"].ToString());  
            FetchDateTimeSpan(ViewOrdersPageView.ViewOrdersPageSelectedDatarow);
            if (ViewOrdersPageView.ViewOrdersPageGetTimeDifference.TotalHours <= 6 || CurrentStatusID != 4 || CurrentStatusID != 5)
            {
                mod.CancelOrder(obj);
            }
            else
            {
                MessageBox.Show("Cannot Cancel if Transaction Is Compelte or Beyond 6 Hourse After Purchased");
            }
            
            
        }

        public void OrdersPageGetSelectedDatarow()
        {
            DataRow dr = ViewOrdersPageView.ViewOrdersPageDatatableOfOrders.Rows[ViewOrdersPageView.ViewOrdersPageListOfOrders.CurrentCell.RowIndex];
            ViewOrdersPageView.ViewPOrdersPageProductManagement.Text = dr["ProductManagementID"].ToString();        
            ViewOrdersPageView.ViewOrdersPageSelectedDatarow = dr;
      


        }

}
}
