using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface BuyItemsPageInterface
    {

        TextBox BuyItemsPageProductNameTxB { get; set; }
        TextBox BuyItemsPageProductStockTxB { get; set; }
        TextBox BuyItemsPageProductPriceTxB { get; set; }
        TextBox BuyItemsPageProductQuantityTxB { get; set; }
        TextBox BuyItemsPageProductCardSecurityCodeTxB { get; set; }
        TextBox BuyItemsPageProductCardBalanceTxB { get; set; }
        TextBox BuyItemsPageProductCardBalanceAfterPurchaseTxB { get; set; }
        TextBox BuyItemsPageProductTotalPriceTxB { get; set; }

        RichTextBox BuyItemsPageProductDescriptionRichTxB { get; set; }

        RichTextBox BuyItemsPageProductShippingAddressRichTxB { get; set; }

        ComboBox BuyItemsPageProductCardNumberCombo { get; set; }

        DataTable BuyItemsPageDatatableOfCards { get; set; }

        Button BuyItemsPageProductBuyProduct{ get; set; }

        DataRow BuyItemsPageSelectedDatarow { get; set; }
        PictureBox BuyItemsPagePictureBox { get; set; }

        int BuyItemsPageCustomerID { get; set; }
        int BuyItemsPageRetailerID { get; set; }
        string BuyItemsPageConnectionString { get; set; }
    }
}
