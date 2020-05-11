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
    class BuyItemsPagePresenter
    {
        BuyItemsPageInterface BuyItemsPageView;
        BuyItemsPageObject obj = new BuyItemsPageObject();
        BuyItemsPageModel mod = new BuyItemsPageModel();
        public BuyItemsPagePresenter(BuyItemsPageInterface IBuyItemsPageView)
        {
            BuyItemsPageView = IBuyItemsPageView;
           
        }


        public void FetchProductInfo()
        {

            DataRow dr = BuyItemsPageView.BuyItemsPageSelectedDatarow;
      
            BuyItemsPageView.BuyItemsPageProductCardNumberCombo.DisplayMember = "CardNumber";
            BuyItemsPageView.BuyItemsPageProductCardNumberCombo.ValueMember = "CardID";
            BuyItemsPageView.BuyItemsPageProductCardNumberCombo.SelectedIndex = -1;
            BuyItemsPageView.BuyItemsPageProductNameTxB.Text = dr["ProductName"].ToString();
            BuyItemsPageView.BuyItemsPageProductDescriptionRichTxB.Text = dr["Description"].ToString();
            BuyItemsPageView.BuyItemsPageProductStockTxB.Text = dr["Stock"].ToString();
            BuyItemsPageView.BuyItemsPageProductPriceTxB.Text = dr["_Price"].ToString();
            BuyItemsPageView.BuyItemsPagePictureBox.ImageLocation = dr["_ProductImageLocation"].ToString();
            BuyItemsPageView.BuyItemsPageRetailerID = Int32.Parse(dr["_RetailerID"].ToString());
            BuyItemsPageView.BuyItemsPagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            BuyItemsPageView.BuyItemsPageProductBuyProduct.Enabled = false;
        }

        public void GetCardInfo()
        {

            DataRow Dr = BuyItemsPageView.BuyItemsPageDatatableOfCards.Rows[BuyItemsPageView.BuyItemsPageProductCardNumberCombo.SelectedIndex];
            BuyItemsPageView.BuyItemsPageProductCardBalanceTxB.Text = Dr["Balance"].ToString();
            BuyItemsPageView.BuyItemsPageProductCardSecurityCodeTxB.Text = Dr["SecurityCode"].ToString();
        }

        public void CalculateTotalPrice()
        {

            try
            {

                decimal GetPrice = decimal.Parse(BuyItemsPageView.BuyItemsPageProductPriceTxB.Text.ToString());
                decimal GetStock = decimal.Parse(BuyItemsPageView.BuyItemsPageProductStockTxB.Text.ToString());
                decimal GetQuantity = decimal.Parse(BuyItemsPageView.BuyItemsPageProductQuantityTxB.Text.ToString());
                decimal GetCurrentBalance = decimal.Parse(BuyItemsPageView.BuyItemsPageProductCardBalanceTxB.Text.ToString());

                if (GetQuantity <= GetStock)
                {
                    decimal CalculateTotalPrice = GetPrice * GetQuantity;
                    decimal BalanceAfterPurchase = GetCurrentBalance - CalculateTotalPrice;
                    BuyItemsPageView.BuyItemsPageProductTotalPriceTxB.Text = CalculateTotalPrice.ToString();
                    if (BalanceAfterPurchase >= 0)
                    {
                        BuyItemsPageView.BuyItemsPageProductCardBalanceAfterPurchaseTxB.Text = BalanceAfterPurchase.ToString();
                        BuyItemsPageView.BuyItemsPageProductBuyProduct.Enabled = true;
                    }
                    else
                    {

                        MessageBox.Show("Insufficient Card Balance ");
                    }

                }
                else
                {
                    int limit = int.Parse(BuyItemsPageView.BuyItemsPageSelectedDatarow["Stock"].ToString());
                    MessageBox.Show("Quantity Should Be Less than Or Equal to " + limit + "Or Your Account Balance");
                    BuyItemsPageView.BuyItemsPageProductBuyProduct.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Please Enter Numbers only");

            }
            
           
        }

        public void BuyItem()
        {
            int GetNewStock = Int32.Parse(BuyItemsPageView.BuyItemsPageProductStockTxB.Text.ToString());

            obj.BuyItemsPageProductSelectedCardBalance = decimal.Parse(BuyItemsPageView.BuyItemsPageProductCardBalanceAfterPurchaseTxB.Text.ToString());
            obj.BuyItemsPageProductSelectedCardID = Int32.Parse( BuyItemsPageView.BuyItemsPageProductCardNumberCombo.SelectedValue.ToString());
            obj.BuyItemsPageShippingAddress = BuyItemsPageView.BuyItemsPageProductShippingAddressRichTxB.Text;
            obj.BuyItemsPageProductCustomerID = BuyItemsPageView.BuyItemsPageCustomerID;
            obj.ViewAllProductsPageConnectionString = BuyItemsPageView.BuyItemsPageConnectionString;
            obj.BuyItemsPageProductNumberOfPurcahsed = Int32.Parse(BuyItemsPageView.BuyItemsPageProductQuantityTxB.Text.ToString());
            obj.BuyItemsPageProductID = Int32.Parse(BuyItemsPageView.BuyItemsPageSelectedDatarow["ProductID"].ToString());
            
            obj.BuyItemsPageTimePurchased = DateTime.Now;

            obj.BuyItemsPageRetailerID = BuyItemsPageView.BuyItemsPageRetailerID;
      
            obj.BuyItemsPageStock = GetNewStock - obj.BuyItemsPageProductNumberOfPurcahsed;


            mod.BuySelectedProduct(obj);
        }

    }
}
