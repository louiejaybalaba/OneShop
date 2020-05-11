

using MainPage.Interface;
using MainPage.View;
using OnlineShopping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Presenter
{
    class MainPagePresenter
    {
        #region Interface Decleration
        LoginSignUpInterface LoginSignupView;
        MainPageInterface MainPageView;
        MyAccountPageInterface MyAccountPageView;
        SellProductsPageInterface SellProductsPageView;
        ViewAllProductsPageInterface ViewAllProductsPageView;
        BuyItemsPageInterface BuyItemsPageView;
        ViewPendingTransactionsPageInterface ViewPendingTransactionsPageView;
        ViewOrdersPageInterface ViewOrdersPageView;
        ChatBoxInterface ChatBoxView;
        #endregion
        FrmSetupConnection frmSetupConnection = new FrmSetupConnection();
        //ChatBoxInterface ChatBoxView;
        #region CallCLaseConstructor
        public MainPagePresenter(FrmMainPage FrmView)
        {

            LoginSignupView = FrmView;
            MainPageView = FrmView;

            MyAccountPageView = FrmView;
            SellProductsPageView = FrmView;
            ViewAllProductsPageView = FrmView;
            BuyItemsPageView = FrmView;
            ViewOrdersPageView = FrmView;
            ViewPendingTransactionsPageView = FrmView;
            ChatBoxView = FrmView;
            //ChatBoxView = FrmView;
            LoadAccountTypes();
            RemoveTabPage();

        }
        #endregion

        #region MaingPage Region



        public void RefreshCurrentTab()
        {
            MainPageView.isRefreshing = true;
            if (MainPageView.DatagridViewMouseLeave == true)
            {

                if (MainPageView.TabControls.SelectedTab == MainPageView.MyAccountPage)
                {
                    LoadAccountInfo();
                }
                else if (MainPageView.TabControls.SelectedTab == MainPageView.ViewAvailableItemsPage)
                {
                    LoadAllProducts();
                    BuyItemsPageView.BuyItemsPageProductQuantityTxB.Enabled = false;
                }
                else if (MainPageView.TabControls.SelectedTab == MainPageView.ViewPendingTransactionsPage)
                {
                    RetrieveProductStatus();
                }
                else if (MainPageView.TabControls.SelectedTab == MainPageView.ViewOrdersPage)
                {
                    LoadOrdersPage();
                }
                else if (MainPageView.TabControls.SelectedTab == MainPageView.ChatBoxPage)
                {
                    LoadAllChat();
                }


            }



        }
        public void LogOut()
        {
            MainPageView.isLoggedIn = false;
            MainPageView.isRefreshing = false;


            RemoveTabPage();
            SetupConnectionInterface view;
            view = frmSetupConnection;
            MainPageView.TabControls.TabPages.Add(MainPageView.LoginSignupPage);
            LoginSignupView.LoginSingupConnectionString = null;

            ClearAllTextViewOrders();
            CLearAllTextBoxLoginSignup();
            CLearAllTextBoxSellItems();
            ClearAllTextBoxViewAllProducts();
            ClearAllTextBoxBuyItems(); 
            ClearAllTextChatbox();
            ClearAllTextViewPendingTransactions();
            ClearAllTextViewOrders();
            LoadAccountTypes();

            MessageBox.Show("Successfully Logged Out");
        }

        public void CLearAllTextBoxSetupConnection(SetupConnectionInterface view)
        {
            view.SetupConnectionDatabase.Text = "";
            view.SetupConnectionServer.Text = "";
            view.SetupConnectionPort.Text = "";
            view.SetupConnectionPassword.Text = "";
            view.SetupConnectionId.Text = "";
        }

        public void CLearAllTextBoxLoginSignup()
        {
            LoginSignupView.LoginUsernameTxtB.Text = "";
            LoginSignupView.LoginPasswordTxtB.Text = "";
            LoginSignupView.SignUpUsernameTxtB.Text = "";
            LoginSignupView.SignUpPasswordTxtB.Text = "";
            LoginSignupView.SignupFirstNameTxtB.Text = "";
            LoginSignupView.SingupLastNameTxtB.Text = "";
        }

        public void CLearAllTextBoxSellItems()
        {
            SellProductsPageView.SellProductsPageProductNameTxB.Text = "";

            SellProductsPageView.SellProductsPageProductStockTxB.Text = "";
            SellProductsPageView.SellProductsPageProductPriceTxB.Text = "";

            SellProductsPageView.SellProductsPageProductDescriptionRichTxB.Text = "";
            SellProductsPageView.SellProductsPageProductPicturePictureB.ImageLocation = "";
        }
        public void ClearAllTextBoxViewAllProducts()
        {
            ViewAllProductsPageView.ViewAllProductsPageSellerFirstName.Text =  "";
            ViewAllProductsPageView.ViewAllProductsPageSellerLastName.Text = "";
            ViewAllProductsPageView.ViewAllProductsPageReStockTxB.Text = "";
            ViewAllProductsPageView.ViewAllProductsPageSelectedDatarow = null;
            ViewAllProductsPageView.ViewAllProductsPageProductImage.ImageLocation = "";

        }
        public void ClearAllTextBoxBuyItems()
        {

            BuyItemsPageView.BuyItemsPageProductQuantityTxB.Text="";
            BuyItemsPageView.BuyItemsPageProductCardSecurityCodeTxB.Text="";
            BuyItemsPageView.BuyItemsPageProductCardBalanceTxB.Text="";
            BuyItemsPageView.BuyItemsPageProductCardBalanceAfterPurchaseTxB.Text="";
            BuyItemsPageView.BuyItemsPageProductTotalPriceTxB.Text="";
            BuyItemsPageView.BuyItemsPageProductShippingAddressRichTxB.Text="";
            BuyItemsPageView.BuyItemsPageProductCardNumberCombo.SelectedIndex = -1;

        }

        public void ClearAllTextChatbox()
        {
            ChatBoxView.TxtChat.Text = "";
        }

        public void ClearAllTextViewPendingTransactions()
        {
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageShippingDate.Value = DateTime.Now;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageDeliveryDate.Value = DateTime.Now;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageProductManagementIDTxB.Text = "";
           
        }
        public void ClearAllTextViewOrders()
        {

            ViewOrdersPageView.ViewOrdersPageFilterByProductStatus.Text = "";
            ViewOrdersPageView.ViewPOrdersPageProductManagement.Text = "";
        }


        #endregion
        #region LoginSignUp Region
        public void LoadAccountTypes()
        {


            LoginSingupPresenter presenter = new LoginSingupPresenter(LoginSignupView);
            presenter.LoadAccountTypes();
 
        }
        public void Login()
        {
            LoginSingupPresenter LoginPresenter = new LoginSingupPresenter(LoginSignupView);
            if (LoginSignupView.LoginSingupConnectionString == null)
            {
                MessageBox.Show("Please Setup Connection First");
                return;
            }
            if (LoginPresenter.Login() == true)
            {
                MainPageView.isLoggedIn = true;
                MyAccountPageView.MyAccountPageAccountID = LoginSignupView.LoginSingupAccountID;
                MyAccountPageView.MyAccountPageConnectionString = LoginSignupView.LoginSingupConnectionString;
                LoadAccountInfo();

                MessageBox.Show("Successfully Signed Logged In");
                RemoveTabPage();
            }
            else
            {
                MessageBox.Show("Log in Failed Account Not Found");
            }

        }


        public void RemoveTabPage()
        {
            MainPageView.isRefreshing = false;
            if (MainPageView.isLoggedIn == false)
            {
                MainPageView.TabControls.TabPages.Remove(MainPageView.SellItemsPage);
                MainPageView.TabControls.TabPages.Remove(MainPageView.ViewAvailableItemsPage);
                MainPageView.TabControls.TabPages.Remove(MainPageView.MyAccountPage);
                MainPageView.TabControls.TabPages.Remove(MainPageView.BuyItemsPage);
                MainPageView.TabControls.TabPages.Remove(MainPageView.ViewPendingTransactionsPage);
                MainPageView.TabControls.TabPages.Remove(MainPageView.ChatBoxPage);
                MainPageView.TabControls.TabPages.Remove(MainPageView.ViewOrdersPage);
            }
            else
            {
                MainPageView.TabControls.TabPages.Remove(MainPageView.LoginSignupPage);
                MainPageView.TabControls.TabPages.Add(MainPageView.MyAccountPage);
                MainPageView.TabControls.TabPages.Add(MainPageView.ChatBoxPage);
                MainPageView.TabControls.TabPages.Add(MainPageView.ViewAvailableItemsPage);       
                LoadAllProducts();
                if (MyAccountPageView.MyAccountPageAccountTypeID == 0)
                {
                    MainPageView.TabControls.TabPages.Add(MainPageView.ViewOrdersPage);
                    ViewAllProductsPageView.ViewAllProductsPageViewMyItems.Visible = false;
                    ViewOrdersLoadProductStatus();
                    LoadOrdersPage();
                    ViewAllProductsPageView.ViewAllProductsPageViewMyItems.Hide();
                }
                else
                {
                    MainPageView.TabControls.TabPages.Add(MainPageView.SellItemsPage);
                    MainPageView.TabControls.TabPages.Add(MainPageView.ViewPendingTransactionsPage);
                    SellProductsPageView.SellProductsPageConnectionString = LoginSignupView.LoginSingupConnectionString;
                    ViewAllProductsPageView.ViewAllProductsPageViewMyItems.Visible = true;
                    LoadProductType();
                    RetrieveProductStatus();
                    ViewAllProductsPageView.ViewAllProductsPageViewMyItems.Show();
                }


            }
        


        }
        public void SignUp()
        {
            LoginSingupPresenter SignupPresenter = new LoginSingupPresenter(LoginSignupView);
            if (SignupPresenter.SignUp() == true)
            {
                MessageBox.Show("Successfully Signed Up");
            }
        }
        #endregion

        #region SellitemPage Region

        public void LoadProductType()
        {
            SellProductsPresenter presenter = new SellProductsPresenter(SellProductsPageView);
            presenter.LoadProductType();

        }
        public void SellItem()
        {
            SellProductsPageView.SellProductsPageRetailerID = LoginSignupView.LoginSingupRetailerID;
            SellProductsPresenter presenter = new SellProductsPresenter(SellProductsPageView);
            presenter.PostItem();
        }
        #endregion
        #region MyAccountPage Region
       
        public void UpdateAccountInfo()
        {
   
            MyAccountPagePresenter MyAccountPresenter = new MyAccountPagePresenter(MyAccountPageView);
            MyAccountPresenter.UpdateAccountInfo();

        }

        public void LoadAccountInfo()
        {
            MainPageView.DatagridViewMouseLeave = true;
            MyAccountPageView.MyAccountPageIsRefreshing = MainPageView.isRefreshing;
            MyAccountPagePresenter MyAccountPresenter = new MyAccountPagePresenter(MyAccountPageView);
            MyAccountPresenter.LoadAccountInfo();
    
               
          


        }

        public void AddCard()
        {
            try
            {
                MyAccountPageView.MyAccountPageCardNumber = Int32.Parse(MyAccountPageView.MyAccountPageCardNumberTxB.Text.ToString());
                MyAccountPageView.MyAccountPageCardSecurityCode = Int32.Parse(MyAccountPageView.MyAccountPageSecurityCodeTxB.Text.ToString());
                MyAccountPageView.MyAccountPageCardBalance = Decimal.Parse(MyAccountPageView.MyAccountPageBalanceTxB.Text.ToString());
                MyAccountPageView.MyAccountPageCustomerID = LoginSignupView.LoginSingupCustomerID;
                MyAccountPagePresenter MyAccountPresenter = new MyAccountPagePresenter(MyAccountPageView);
                MyAccountPresenter.AddCard();
                MyAccountPresenter.LoadCardInfo();

            }
            catch (Exception e)
            {
         
                MessageBox.Show(e.Message +"Please enter Numbers only");
            } 
        }
        public void RemoveCard()
        {
            MyAccountPagePresenter MyAccountPresenter = new MyAccountPagePresenter(MyAccountPageView);
            MyAccountPresenter.RemoveCardInfo();

        }

        #endregion

        #region ViewAllProductsPage Region
        public void BrowsePicture()
        {
            SellProductsPresenter presenter = new SellProductsPresenter(SellProductsPageView);
            presenter.BrowsePicture();

        }
      
        public void LoadAllProducts()
        {
            ViewAllProductsPageView.ViewAllProductsPageisRefreshing = MainPageView.isRefreshing;
            ViewAllProductsPageView.ViewAllProductsPageConnectionString = LoginSignupView.LoginSingupConnectionString;
            ViewAllProductsPageView.ViewAllProductsPageAccountTypeID = LoginSignupView.LoginSingupAccountTypeID;
            ViewAllProductsPageView.ViewAllProductsPageRetailerID = LoginSignupView.LoginSingupRetailerID;
            ViewAllProductsPagePresenter ViewAllProductspresenter = new ViewAllProductsPagePresenter(ViewAllProductsPageView);
            
            if (MainPageView.isRefreshing != true)
            {
                ViewAllProductspresenter.LoadFilterByProductType();
            }
            ViewAllProductspresenter.LoadAllProducts();

        }
   
        public void ViewProductSellerInfo()
        {
            ViewAllProductsPagePresenter presenter =new  ViewAllProductsPagePresenter(ViewAllProductsPageView);
            presenter.GetRetailerInfo();

        }

        public void FilterByProductType()
        {
            ViewAllProductsPageView.ViewAllProductsPageSearchIsClicked = true;
            ViewAllProductsPagePresenter presenter = new ViewAllProductsPagePresenter(ViewAllProductsPageView);
            presenter.LoadAllProducts();
            if (LoginSignupView.LoginSingupAccountID == 0)
            {
                AddColumnForCustomer(presenter);

            }

        }
        public void ChangeToViewMyItems()
        {
            if (ViewAllProductsPageView.ViewAllProductsPageViewMyItems.Checked == true)
            {
                ViewAllProductsPageView.ViewAllProductsPageViewMyItemIsClicked = true;
                ViewAllProductsPageView.ViewAllProductsPageReStockPanel.Visible = true;
            }
            else
            {
                ViewAllProductsPageView.ViewAllProductsPageRetailerID = LoginSignupView.LoginSingupRetailerID;
                ViewAllProductsPageView.ViewAllProductsPageViewMyItemIsClicked = false;
                ViewAllProductsPagePresenter presenter = new ViewAllProductsPagePresenter(ViewAllProductsPageView);
                ViewAllProductsPageView.ViewAllProductsPageReStockPanel.Visible = false;
                presenter.LoadAllProducts();
            }
        }

        public void ReStockItem()
        {
            
            ViewAllProductsPagePresenter presenter = new ViewAllProductsPagePresenter(ViewAllProductsPageView);
            presenter.ReStockItem();
        }

        public void AddColumnForCustomer(ViewAllProductsPagePresenter presenter)
        {
            presenter.AddColumnForCustomer();

        }
        #endregion

        #region BuyItemsPage Region
        public void InvokeViewAllProductsCellContentClick()
        {
            if (LoginSignupView.LoginSingupAccountTypeID == 0)
            {
                if (MainPageView.TabControls.TabPages.Contains(MainPageView.BuyItemsPage) != true)
                {
                    MainPageView.TabControls.TabPages.Add(MainPageView.BuyItemsPage);
                    MainPageView.TabControls.SelectedTab = MainPageView.BuyItemsPage;
                }
                else
                {
                    MainPageView.TabControls.TabPages.Remove(MainPageView.BuyItemsPage);
                    MainPageView.TabControls.TabPages.Add(MainPageView.BuyItemsPage);
                    MainPageView.TabControls.SelectedTab = MainPageView.BuyItemsPage;
                }
                BuyItemsPageView.BuyItemsPageConnectionString = LoginSignupView.LoginSingupConnectionString;
                BuyItemsPageView.BuyItemsPageSelectedDatarow = ViewAllProductsPageView.ViewAllProductsPageSelectedDatarow;
                BuyItemsPageView.BuyItemsPageProductCardNumberCombo.DataSource = MyAccountPageView.MyAccountPageDatatableOfCards;
                BuyItemsPagePresenter BuyItemsPresenter = new BuyItemsPagePresenter(BuyItemsPageView);
                BuyItemsPresenter.FetchProductInfo();
            }
            
          
            //BuyItemsPresenter.FetchProductInfo();
        }


        public void GetCardInfo()
        {
            BuyItemsPageView.BuyItemsPageProductQuantityTxB.Enabled = true;
            BuyItemsPageView.BuyItemsPageDatatableOfCards = MyAccountPageView.MyAccountPageDatatableOfCards;
            BuyItemsPagePresenter BuyItemsPresenter = new BuyItemsPagePresenter(BuyItemsPageView);
            BuyItemsPresenter.GetCardInfo();

        }

        public void CalculateTotalPrice()
        {
            BuyItemsPagePresenter BuyItemsPresenter = new BuyItemsPagePresenter(BuyItemsPageView);
            BuyItemsPresenter.CalculateTotalPrice();
        }

        public void BuyItem()
        {
            BuyItemsPageView.BuyItemsPageCustomerID = LoginSignupView.LoginSingupCustomerID;
            BuyItemsPagePresenter BuyItemsPresenter = new BuyItemsPagePresenter(BuyItemsPageView);
            BuyItemsPresenter.BuyItem();
            MainPageView.TabControls.TabPages.Remove(MainPageView.BuyItemsPage);

        }



        #endregion

        #region ViewPendingTransactionsPage

        public void RetrieveProductStatus()
        {
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageConnectionString = LoginSignupView.LoginSingupConnectionString;
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageRetailerID = LoginSignupView.LoginSingupRetailerID;
            ViewPendingTransactionsPagePresenter presenter = new ViewPendingTransactionsPagePresenter(ViewPendingTransactionsPageView);
            if (MainPageView.isRefreshing != true)
            {
                presenter.RetrieveProductStatus();
            }
            presenter.RetrieveAllTransactions();
        }
        public void FilterViewPendingTransactions()
        {
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageSelectedProductStatusID = int.Parse(ViewPendingTransactionsPageView.ViewPendingTransactionsPageFilterByProductStatusCombo.SelectedValue.ToString());
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageSearchIsCLicked = true;
            ViewPendingTransactionsPagePresenter presenter = new ViewPendingTransactionsPagePresenter(ViewPendingTransactionsPageView);
            presenter.RetrieveAllTransactions();
        }
        public void GetShippingAndProductStatus()
        {
            ViewPendingTransactionsPageView.ViewPendingTransactionsPageRetailerID = LoginSignupView.LoginSingupRetailerID;
            ViewPendingTransactionsPagePresenter presenter = new ViewPendingTransactionsPagePresenter(ViewPendingTransactionsPageView);
            presenter.GetShippingAndProductStatus();

        }

        public void UpdateShippingInfo()
        {
            ViewPendingTransactionsPagePresenter presenter = new ViewPendingTransactionsPagePresenter(ViewPendingTransactionsPageView);
            presenter.UpdateShippingInfo();


        }

        public void UpdateProductStatus()
        {
            ViewPendingTransactionsPagePresenter presenter = new ViewPendingTransactionsPagePresenter(ViewPendingTransactionsPageView);
            presenter.UpdateProductStatus();
            MainPageView.DatagridViewMouseLeave = false;
            RefreshCurrentTab();
            
   
        }
        #endregion

        #region ViewOrdersPage
        public void LoadOrdersPage()
        {
            ViewOrdersPageView.ViewOrdersPageSearchIsClicked = true;
            ViewOrdersPageView.ViewOrdersPageCustomerID = LoginSignupView.LoginSingupCustomerID;
            ViewOrdersPagePresenter presenter = new ViewOrdersPagePresenter(ViewOrdersPageView);
            presenter.LoadOrdersPage();
        }
        public void ViewOrdersLoadProductStatus()
        {
            ViewOrdersPageView.ViewOrdersPageConnectionString = LoginSignupView.LoginSingupConnectionString;
            ViewOrdersPagePresenter presenter = new ViewOrdersPagePresenter(ViewOrdersPageView);
            presenter.ViewOrdersLoadProductStatus();
        }
        public void OrdersPageGetSelectedDatarow()
        {
            ViewOrdersPagePresenter presenter = new ViewOrdersPagePresenter(ViewOrdersPageView);
            presenter.OrdersPageGetSelectedDatarow();
        }

        public void CancelOrder()
        {
         ViewOrdersPagePresenter presenter = new ViewOrdersPagePresenter(ViewOrdersPageView);
         presenter.CancelOrder();
        }
        #endregion

        #region ChatBoxRegion
        internal void SubmitChat()
        {
            ChatBoxView.accountID = LoginSignupView.LoginSingupAccountID;
            ChatBoxView.ViewAllChatPageConnectionString = LoginSignupView.LoginSingupConnectionString;
            ChatBoxPresenter presenter = new ChatBoxPresenter(ChatBoxView);
            presenter.SubmitChat();
        }

        internal void LoadAllChat()
        {
            ChatBoxView.ViewAllChatPageConnectionString = LoginSignupView.LoginSingupConnectionString;
       
                ChatBoxPresenter presenter = new ChatBoxPresenter(ChatBoxView);
            presenter.LoadAllChats();

        }
#endregion



        #region SetupConnectionForm
        public void SetupConnection()
        {
    

            if (frmSetupConnection.ShowDialog() == DialogResult.OK)
            {
                LoginSignupView.LoginSingupConnectionString = "Server=" + frmSetupConnection.SetupConnectionServer.Text + ";Port=" + frmSetupConnection.SetupConnectionPort.Text + "; User Id=" + frmSetupConnection.SetupConnectionId.Text
                + ";Password=" + frmSetupConnection.SetupConnectionPassword.Text + "; Database=" + frmSetupConnection.SetupConnectionDatabase.Text + ";";
            }
        }
        #endregion

    }

}
