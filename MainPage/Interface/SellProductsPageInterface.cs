using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface SellProductsPageInterface
    {
        TextBox SellProductsPageProductNameTxB { get; set; }

        TextBox SellProductsPageProductStockTxB { get; set; }
        TextBox SellProductsPageProductPriceTxB { get; set; }

        RichTextBox SellProductsPageProductDescriptionRichTxB { get; set; }
        PictureBox SellProductsPageProductPicturePictureB { get; set; }
        Button SellProductsPagePostItem { get; set; }
        Button SellProductsPageBrowsePicture{ get; set; }

        ComboBox SellProductsPageProductTypeComb { get; set; }

        int SellProductsPageProductTypeID { get; set; }
        int SellProductsPageRetailerID { get; set; }
        string SellProductsPageProductPictureLocation { get; set; }
        string SellProductsPageConnectionString { get; set; }

    }
}
