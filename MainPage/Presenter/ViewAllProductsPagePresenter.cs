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
    class ViewAllProductsPagePresenter
    {

        ViewAllProductsPageInterface ViewAllProductsPageView;
        ViewAllProductsPageModel mod = new ViewAllProductsPageModel();
        ViewAllProductsPageObject obj = new ViewAllProductsPageObject();
        public ViewAllProductsPagePresenter(ViewAllProductsPageInterface IViewAllProductsPageView)
        {
            ViewAllProductsPageView = IViewAllProductsPageView;
            obj.ConnectionString = ViewAllProductsPageView.ViewAllProductsPageConnectionString;
        }

        public void LoadAllProducts()
        {       
            CheckIfFiltered();
            BindDataSourceAndHideColumns();
            //AddColumnForCustomer();
        }
 
        public void CheckIfFiltered()
        {
            obj.ViewAllProductsPageSearchIsCLicked = ViewAllProductsPageView.ViewAllProductsPageSearchIsClicked;
            if (obj.ViewAllProductsPageSearchIsCLicked == true)
            {
                obj.ViewAllProductsPageProductTypeID = int.Parse(ViewAllProductsPageView.ViewAllProductsPageFilterByProductTypeCombo.SelectedValue.ToString());
            }

            if (ViewAllProductsPageView.ViewAllProductsPageViewMyItemIsClicked == false)
            {
             
                ViewAllProductsPageView.ViewAllProductsPageDatatable = mod.LoadAllProducts(obj);

            }
            else
            {
                obj.ViewAllProductsPageRetailerID = ViewAllProductsPageView.ViewAllProductsPageRetailerID;
                ViewAllProductsPageView.ViewAllProductsPageDatatable = mod.LoadAllMyProducts(obj);

            }
        }
        public void BindDataSourceAndHideColumns()
        {
            int count = 0;
            ViewAllProductsPageView.ViewAllProductsPageGridview.DataSource = ViewAllProductsPageView.ViewAllProductsPageDatatable;
            foreach (DataGridViewColumn dg in ViewAllProductsPageView.ViewAllProductsPageGridview.Columns)
            {
                if (dg.Name.Contains("_"))
                {
                    ViewAllProductsPageView.ViewAllProductsPageGridview.Columns[count].Visible = false;

                }
                else
                {
                    ViewAllProductsPageView.ViewAllProductsPageGridview.Columns[count].ReadOnly = true;

                }
                count += 1;
            }
        }

        public void AddColumnForCustomer()
        {
            DataGridViewButtonColumn butt = new DataGridViewButtonColumn();
            butt.HeaderText = "Buy This Item";
            butt.Name = "BuyNow";
            if (ViewAllProductsPageView.ViewAllProductsPageAccountTypeID == 0 &&
                  ViewAllProductsPageView.ViewAllProductsPageisRefreshing == false &&
                  ViewAllProductsPageView.ViewAllProductsPageViewMyItemIsClicked == false)
            {
                ViewAllProductsPageView.ViewAllProductsPageGridview.Columns.Add(butt);
                ViewAllProductsPageView.ViewAllProductsPageGridview.Columns["BuyNow"].DefaultCellStyle.NullValue = "BuyNow!";
            }

        }

        


    public void LoadFilterByProductType()
        {
            ViewAllProductsPageView.ViewAllProductsPageFilterByProductTypeCombo.DataSource = mod.LoadProductTypes(obj);
            ViewAllProductsPageView.ViewAllProductsPageFilterByProductTypeCombo.DisplayMember = "Description";
            ViewAllProductsPageView.ViewAllProductsPageFilterByProductTypeCombo.ValueMember = "ProductTypeID";
            ViewAllProductsPageView.ViewAllProductsPageFilterByProductTypeCombo.SelectedIndex = 1;

        }
        public void GetRetailerInfo()
        {

            try
            {
           
                DataRow dr = ViewAllProductsPageView.ViewAllProductsPageDatatable.Rows[ViewAllProductsPageView.ViewAllProductsPageGridview.CurrentCell.RowIndex];
                ViewAllProductsPageView.ViewAllProductsPageSellerFirstName.Text = dr["_FirstName"].ToString();
                ViewAllProductsPageView.ViewAllProductsPageSellerLastName.Text = dr["_LastName"].ToString();
                ViewAllProductsPageView.ViewAllProductsPageProductImage.ImageLocation = dr["_ProductImageLocation"].ToString();
                            
                //ViewAllProductsPageView.imageLoc = dt.Rows[0]["Image"].ToString();     
                ViewAllProductsPageView.ViewAllProductsPageProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
                ViewAllProductsPageView.ViewAllProductsPageSelectedDatarow = dr;
            }
            catch {
            }
        }

        public void ReStockItem()
        {
            obj.ConnectionString = ViewAllProductsPageView.ViewAllProductsPageConnectionString;
            obj.ViewAllProductsPageProductID = int.Parse(ViewAllProductsPageView.ViewAllProductsPageSelectedDatarow["ProductID"].ToString());
            obj.ViewAllProductsPageReStock =
            int.Parse(ViewAllProductsPageView.ViewAllProductsPageSelectedDatarow["Stock"].ToString()) + int.Parse(ViewAllProductsPageView.ViewAllProductsPageReStockTxB.Text.ToString());
            mod.ReStockItem(obj);

        }

    }
}
