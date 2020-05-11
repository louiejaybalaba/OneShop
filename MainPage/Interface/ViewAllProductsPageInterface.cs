using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface ViewAllProductsPageInterface
    {
        DataGridView ViewAllProductsPageGridview { get; set; }
        TextBox ViewAllProductsPageSellerFirstName { get; set; }
        TextBox ViewAllProductsPageSellerLastName { get; set; }
        TextBox ViewAllProductsPageReStockTxB { get; set; }
        DataTable ViewAllProductsPageDatatable { get; set; }
        PictureBox ViewAllProductsPageProductImage { get; set; }
        ComboBox ViewAllProductsPageFilterByProductTypeCombo { get; set; }
        DataRow ViewAllProductsPageSelectedDatarow{ get; set; }



        CheckBox ViewAllProductsPageViewMyItems { get; set; }
        bool ViewAllProductsPageSearchIsClicked { get; set; }
        bool ViewAllProductsPageViewMyItemIsClicked { get; set; }
        bool ViewAllProductsPageisRefreshing { get; set; }
        int  ViewAllProductsPageRetailerID { get; set; }
        int ViewAllProductsPageAccountTypeID { get; set; }
        string ViewAllProductsPageConnectionString { get; set; }

        Panel ViewAllProductsPageReStockPanel { get; set; }
   
    }
}
