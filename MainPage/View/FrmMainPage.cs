using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainPage.Interface;
using MainPage.Presenter;
using MainPage.View;
using OnlineShopping.GlobalTransaction;

namespace OnlineShopping
{
    public partial class FrmMainPage : Form, LoginSignUpInterface, MainPageInterface, MyAccountPageInterface,
                                             SellProductsPageInterface, ViewAllProductsPageInterface,
                                             BuyItemsPageInterface, ViewPendingTransactionsPageInterface,
                                             ViewOrdersPageInterface , ChatBoxInterface
    {
        MainPagePresenter presenter;
        public FrmMainPage()
        {
            
            InitializeComponent();
            
            presenter = new MainPagePresenter(this);
          
        }

  
        public TextBox LoginUsernameTxtB
        {
            get { return textBox1; }
            set { textBox1 = value; }
        }

        public TextBox LoginPasswordTxtB
        {
            get { return textBox2; }
            set { textBox2 = value; }
        }

        public Button LoginBtn
        {
            get { return button1; }
            set { button1 = value; }
        }
        
        public Button LoginSetUpConnection
        {
            get { return button4; }
            set { button4 = value; }
        }
        public TextBox SignUpUsernameTxtB
        {
            get { return textBox3; }
            set { textBox3 = value; }
        }
        public TextBox SignUpPasswordTxtB
        {
            get { return textBox4; }
            set { textBox4 = value; }
        }
        public TextBox SignupFirstNameTxtB
        {
            get { return textBox5; }
            set { textBox5 = value; }
        }
        public TextBox SingupLastNameTxtB
        {
            get { return textBox6; }
            set { textBox6 = value; }
        }
        public DateTimePicker SingupDateOfBirth
        {
            get { return dateTimePicker1; }
            set { dateTimePicker1 = value; }
        }
        public ComboBox AccountType
        {
            get { return comboBox1; }
            set { comboBox1 = value; }
        }
        public Button SignUpSubmit
        {
            get { return button2; }
            set { button2 = value; }
        }

        private string _LoginSingupConnectionString;
        public string LoginSingupConnectionString
        {
            get { return _LoginSingupConnectionString; }
            set { _LoginSingupConnectionString = value; }
        }

        public TabPage LoginSignupPage
        {
            get { return tabPage1; }
            set { tabPage1 = value; }
        }
        public TabPage MyAccountPage
        {
            get { return tabPage2; }
            set { tabPage2 = value; }
        }


        
        public TabControl TabControls
        {
            get { return tabControl1; }
            set { tabControl1 = value; }
        }

        public TextBox MyAccountPageUsernameTxB
        {
            get { return textBox10; }
            set { textBox10 = value; }
        }
        public TextBox MyAccountPagePasswordTxB
        {
            get { return textBox9; }
            set { textBox9 = value; }
        }

        private int _LoginSingupAccountID;
        public int LoginSingupAccountID
        {
            get { return _LoginSingupAccountID; }
            set { _LoginSingupAccountID = value; }
        }

        private bool _isLoggedIn;
        public bool isLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }
        private int _MyAccountPageAccountID;
        public int MyAccountPageAccountID
        {
            get { return _MyAccountPageAccountID; }
            set { _MyAccountPageAccountID = value; }
        }
        private string _MyAccountPageConnectionString;
        public string MyAccountPageConnectionString
        {
            get { return _MyAccountPageConnectionString; }
            set { _MyAccountPageConnectionString = value; }
        }

        public TextBox MyAccountPageAccountTypeTxB
        {
            get { return textBox13; }
            set { textBox13 = value; }
        }

        public TextBox MyAccountPageFirstNameTxB
        {
            get { return textBox8; }
            set { textBox8 = value; }
        }

        public TextBox MyAccountPageProfitsNumberOfPurchase
        {
            get { return textBox11; }
            set { textBox11 = value; }
        }

        public TextBox MyAccountPageCardNumberTxB
        {
            get { return textBox12; }
            set { textBox12 = value; }
        }

        public TextBox MyAccountPageSecurityCodeTxB
        {
            get { return textBox14; }
            set { textBox14 = value; }
        }
        public TextBox MyAccountPageBalanceTxB
        {
            get { return textBox15; }
            set { textBox15 = value; }
        }

        public DataGridView MyAccountPageListOfCards
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
        private DataTable _MyAccountPageDatatableOfCards;
        public DataTable MyAccountPageDatatableOfCards
        {
            get { return _MyAccountPageDatatableOfCards; }
            set { _MyAccountPageDatatableOfCards = value; }
        }
        
        public DateTimePicker MyAccountPageDateOfBirthDTP
        {
            get { return dateTimePicker2; }
            set { dateTimePicker2 = value; }
        }
        
        public Panel MyAccountPageCardInfo
        {
            get { return panel4; }
            set { panel4 = value; }
        }
        
        public Button MyAccountPageAddCard
        {
            get { return button5; }
            set { button5 = value; }
        }
        private int _MyAccountPageAccountTypeID;
        public int MyAccountPageAccountTypeID
        {
            get { return _MyAccountPageAccountTypeID; }
            set { _MyAccountPageAccountTypeID = value; }
        }
        

        public TextBox MyAccountPageLastNameTxB
        {
            get { return textBox7; }
            set { textBox7 = value; }
        }

        private int _MyAccountPageRetailerID;
        public int MyAccountPageRetailerID
        {
            get { return _MyAccountPageRetailerID; }
            set { _MyAccountPageRetailerID = value; }
        }

        private int _MyAccountPageCustomerID;
        public int MyAccountPageCustomerID
        {
            get { return _MyAccountPageCustomerID; }
            set { _MyAccountPageCustomerID = value; }
        }

        private int _MyAccountPageCardNumber;
        public int MyAccountPageCardNumber
        {
            get { return _MyAccountPageCardNumber; }
            set { _MyAccountPageCardNumber = value; }
        }
        private int _MyAccountPageCardSecurityCode;
        public int MyAccountPageCardSecurityCode
        {
            get { return _MyAccountPageCardSecurityCode; }
            set { _MyAccountPageCardSecurityCode = value; }
        }

        private decimal _MyAccountPageCardBalance;
        public decimal MyAccountPageCardBalance
        {
            get { return _MyAccountPageCardBalance; }
            set { _MyAccountPageCardBalance = value; }
        }

        private int _LoginSingupCustomerID;
        public int LoginSingupCustomerID
        {
            get { return _LoginSingupCustomerID; }
            set { _LoginSingupCustomerID = value; }
        }
        private int  _LoginSingupRetailerID;
        public int LoginSingupRetailerID
        {
            get { return _LoginSingupRetailerID; }
            set { _LoginSingupRetailerID = value; }
        }
        private int _LoginSingupAccountTypeID;
        public int LoginSingupAccountTypeID
        {
            get { return _LoginSingupAccountTypeID; }
            set { _LoginSingupAccountTypeID = value; }
        }

        public TabPage SellItemsPage
        {
            get { return tabPage3; }
            set { tabPage3 = value; }
        }

        public TextBox SellProductsPageProductNameTxB
        {
            get { return textBox16; }
            set { textBox16 = value; }
        }
        private int _SellProductsPageProductTypeID;
        public int SellProductsPageProductTypeID
        {
            get { return _SellProductsPageProductTypeID; }
            set { _SellProductsPageProductTypeID = value; }
        }
        
        public TextBox SellProductsPageProductStockTxB
        {
            get { return textBox17; }
            set { textBox17 = value; }
        }

        public TextBox SellProductsPageProductPriceTxB
        {
            get { return textBox18; }
            set { textBox18 = value; }
        }
        public RichTextBox SellProductsPageProductDescriptionRichTxB
        {
            get { return richTextBox1; }
            set { richTextBox1 = value; }
        }
        public PictureBox SellProductsPageProductPicturePictureB
        {
            get { return pictureBox1; }
            set { pictureBox1 = value; }
        }

        public Button SellProductsPagePostItem
        {
            get { return button8; }
            set { button8 = value; }
        }
        public Button SellProductsPageBrowsePicture
        {
            get { return button9; }
            set { button9 = value; }
        }
        private string _SellProductsPageProductPictureLocation;
        public string SellProductsPageProductPictureLocation
        {
            get { return _SellProductsPageProductPictureLocation; }
            set { _SellProductsPageProductPictureLocation = value; }
        }
        
        public ComboBox SellProductsPageProductTypeComb
        {
            get { return comboBox2; }
            set { comboBox2 = value; }
        }
        private string _SellProductsPageConnectionString;
        public string SellProductsPageConnectionString
        {
            get { return _SellProductsPageConnectionString; }
            set { _SellProductsPageConnectionString = value; }
        }
        private int _SellProductsPageRetailerID;
        public int SellProductsPageRetailerID
        {
            get { return _SellProductsPageRetailerID; }
            set { _SellProductsPageRetailerID = value; }
        }

        public TabPage ViewAvailableItemsPage
        {
            get { return tabPage4; }
            set { tabPage4 = value; }
        }

        public DataGridView ViewAllProductsPageGridview
        {
            get { return dataGridView2; }
            set { dataGridView2 = value; }
        }

        public TextBox ViewAllProductsPageSellerFirstName
        {
            get { return textBox19; }
            set { textBox19 = value; }
        }
        public TextBox ViewAllProductsPageSellerLastName
        {
            get { return textBox20; }
            set { textBox20 = value; }
        }
        private DataTable _ViewAllProductsPageDatatables;
        public DataTable ViewAllProductsPageDatatable
        {
            get { return _ViewAllProductsPageDatatables; }
            set { _ViewAllProductsPageDatatables = value; }
        }

        private string _ViewAllProductsPageConnectionString;
        public string ViewAllProductsPageConnectionString
        {
            get { return _ViewAllProductsPageConnectionString; }
            set { _ViewAllProductsPageConnectionString = value; }
        }
        
        public ComboBox ViewAllProductsPageFilterByProductTypeCombo
        {
            get { return comboBox3; }
            set { comboBox3 = value; }
        }

        private bool _ViewAllProductsPageSearchIsClicked;
        public bool ViewAllProductsPageSearchIsClicked
        {
            get { return _ViewAllProductsPageSearchIsClicked; }
            set { _ViewAllProductsPageSearchIsClicked = value; }

        }
        private bool _MyAccountPageIsRefreshing;
        public bool MyAccountPageIsRefreshing
        {
            get { return _MyAccountPageIsRefreshing; }
            set { _MyAccountPageIsRefreshing = value; }

        }
        
        public ComboBox ViewOrdersPageFilterByProductStatus
        {
            get { return comboBox8; }
            set { comboBox8 = value; }

        }
        
        public TextBox ViewPOrdersPageProductManagement
        {
            get { return textBox32; }
            set { textBox32 = value; }

        }
        
        public DataGridView ViewOrdersPageListOfOrders
        {
            get { return dataGridView5; }
            set { dataGridView5 = value; }

        }
        private DataRow _ViewOrdersPageSelectedDatarow;
        public DataRow ViewOrdersPageSelectedDatarow
        {
            get { return _ViewOrdersPageSelectedDatarow; }
            set { _ViewOrdersPageSelectedDatarow = value; }

        }
        private DataTable _ViewOrdersPageDatatableOfProductStatus;
        public DataTable ViewOrdersPageDatatableOfProductStatus
        {
            get { return _ViewOrdersPageDatatableOfProductStatus; }
            set { _ViewOrdersPageDatatableOfProductStatus = value; }
        }
        private DataTable _ViewOrdersPageDatatableOfOrders;
        public DataTable ViewOrdersPageDatatableOfOrders
        {
            get { return _ViewOrdersPageDatatableOfOrders; }
            set { _ViewOrdersPageDatatableOfOrders = value; }
        }
        private string _ViewOrdersPageConnectionString;
        public string ViewOrdersPageConnectionString
        {
            get { return _ViewOrdersPageConnectionString; }
            set { _ViewOrdersPageConnectionString = value; }
        }
        private int _ViewOrdersPageCustomerID;
        public int ViewOrdersPageCustomerID
        {
            get { return _ViewOrdersPageCustomerID; }
            set { _ViewOrdersPageCustomerID = value; }
        }
        public TimeSpan _ViewOrdersPageGetTimeDifference;
        public TimeSpan ViewOrdersPageGetTimeDifference
        {
            get { return _ViewOrdersPageGetTimeDifference; }
            set { _ViewOrdersPageGetTimeDifference = value; }
        }
        private bool _ViewOrdersPageSearchIsClicked;
        public bool ViewOrdersPageSearchIsClicked
        {
            get { return _ViewOrdersPageSearchIsClicked; }
            set { _ViewOrdersPageSearchIsClicked = value; }
        }
        public TabPage BuyItemsPage
        {
            get { return tabPage5; }
            set { tabPage5 = value; }
        }
        public TabPage ViewPendingTransactionsPage
        {
            get { return tabPage7; }
            set { tabPage7 = value; }
        }
        public TabPage ChatBoxPage
        {
            get { return tabPage6; }
            set { tabPage6 = value; }
        }
        public TabPage ViewOrdersPage
        {
            get { return tabPage8; }
            set { tabPage8 = value; }
        }
        private bool _DatagridViewMouseLeave;
        public bool DatagridViewMouseLeave
        {
            get { return _DatagridViewMouseLeave; }
            set { _DatagridViewMouseLeave = value; }
        }
        private bool _isRefreshing;
        public bool isRefreshing
        {
            get { return _isRefreshing; }
            set { _isRefreshing = value; }
        }
        
        public PictureBox ViewAllProductsPageProductImage
        {
                get { return pictureBox3; }
                set { pictureBox3 = value; }
            
        }
        private DataRow _ViewAllProductsPageSelectedDatarow;
        public DataRow ViewAllProductsPageSelectedDatarow
        {
            get { return _ViewAllProductsPageSelectedDatarow; }
            set { _ViewAllProductsPageSelectedDatarow = value; }
        }
        public CheckBox ViewAllProductsPageViewMyItems
        {
            get { return checkBox1; }
            set { checkBox1 = value; }
        }
        private bool _ViewAllProductsPageViewMyItemIsClicked;
        public bool ViewAllProductsPageViewMyItemIsClicked
        {
            get { return _ViewAllProductsPageViewMyItemIsClicked; }
            set { _ViewAllProductsPageViewMyItemIsClicked = value; }
        }
        private bool _ViewAllProductsPageisRefreshing;
        public bool ViewAllProductsPageisRefreshing
        {
            get { return _ViewAllProductsPageisRefreshing; }
            set { _ViewAllProductsPageisRefreshing = value; }
        }
        private int _ViewAllProductsPageRetailerID;
        public int ViewAllProductsPageRetailerID
        {
            get { return _ViewAllProductsPageRetailerID; }
            set { _ViewAllProductsPageRetailerID = value; }
        }
        private int _ViewAllProductsPageAccountTypeID;
        public int ViewAllProductsPageAccountTypeID
        {
            get { return _ViewAllProductsPageAccountTypeID; }
            set { _ViewAllProductsPageAccountTypeID = value; }
        }
        public Panel ViewAllProductsPageReStockPanel
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        public TextBox ViewAllProductsPageReStockTxB
        {
            get { return textBox30; }
            set { textBox30 = value; }
        }

        public TextBox BuyItemsPageProductNameTxB
        {
            get { return textBox22; }
            set { textBox22 = value; }
        }
        public TextBox BuyItemsPageProductStockTxB
        {
            get { return textBox24; }
            set { textBox24 = value; }
        }
        public TextBox BuyItemsPageProductPriceTxB
        {
            get { return textBox25; }
            set { textBox25 = value; }
        }
        public TextBox BuyItemsPageProductQuantityTxB
        {
            get { return textBox21; }
            set { textBox21 = value; }
        }
        public TextBox BuyItemsPageProductCardSecurityCodeTxB
        {
            get { return textBox27; }
            set { textBox27 = value; }
        }
        public TextBox BuyItemsPageProductCardBalanceTxB
        {
            get { return textBox29; }
            set { textBox29 = value; }
        }
        public TextBox BuyItemsPageProductCardBalanceAfterPurchaseTxB
        {
            get { return textBox28; }
            set { textBox28 = value; }
        }
        public RichTextBox BuyItemsPageProductDescriptionRichTxB
        {
            get { return richTextBox3; }
            set { richTextBox3 = value; }
        }
        public RichTextBox BuyItemsPageProductShippingAddressRichTxB
        {
            get { return richTextBox2; }
            set { richTextBox2 = value; }
        }
        public ComboBox BuyItemsPageProductCardNumberCombo
        {
            get { return comboBox4; }
            set { comboBox4 = value; }
        }
        private DataTable _BuyItemsPageDatatableOfCards;
        public DataTable BuyItemsPageDatatableOfCards
        {
            get { return _BuyItemsPageDatatableOfCards; }
            set { _BuyItemsPageDatatableOfCards = value; }
        }
        public Button BuyItemsPageProductBuyProduct
        {
            get { return button3; }
            set { button3 = value; }
        }
        private DataRow _BuyItemsPageSelectedDatarow;
        public DataRow BuyItemsPageSelectedDatarow
        {
            get { return _BuyItemsPageSelectedDatarow; }
            set { _BuyItemsPageSelectedDatarow = value; }
        }
        public PictureBox BuyItemsPagePictureBox
        {
            get { return pictureBox4; }
            set { pictureBox4 = value; }
        }
        private int _BuyItemsPageCustomerID;
        public int BuyItemsPageCustomerID
        {
            get { return _BuyItemsPageCustomerID; }
            set { _BuyItemsPageCustomerID = value; }
        }
        private int _BuyItemsPageRetailerID;
        public int BuyItemsPageRetailerID
        {
            get { return _BuyItemsPageRetailerID; }
            set { _BuyItemsPageRetailerID = value; }
        }
        private string _BuyItemsPageConnectionString;
        public string BuyItemsPageConnectionString
        {
            get { return _BuyItemsPageConnectionString; }
            set { _BuyItemsPageConnectionString = value; }
        }

        public TextBox BuyItemsPageProductTotalPriceTxB
        {
            get { return textBox23; }
            set { textBox23 = value; }
        }

        public DateTimePicker ViewPendingTransactionsPageShippingDate
        {
            get { return dateTimePicker3; }
            set { dateTimePicker3 = value; }
        }
        public DateTimePicker ViewPendingTransactionsPageDeliveryDate
        {
            get { return dateTimePicker4; }
            set { dateTimePicker4 = value; }
        }
        public ComboBox ViewPendingTransactionsPageFilterByProductStatusCombo
        {
            get { return comboBox5; }
            set { comboBox5 = value; }
        }
        public ComboBox ViewPendingTransactionsPageUpdateProductStatusCombo
        {
            get { return comboBox6; }
            set { comboBox6 = value; }
        }
        private DataRow _ViewPendingTransactionsPageSelectedDatarow;
        public DataRow ViewPendingTransactionsPageSelectedDatarow
        {
            get { return _ViewPendingTransactionsPageSelectedDatarow; }
            set { _ViewPendingTransactionsPageSelectedDatarow = value; }
        }
        private DataTable _ViewPendingTransactionsPageDatatableOfTransactions;
        public DataTable ViewPendingTransactionsPageDatatableOfTransactions
        {
            get { return _ViewPendingTransactionsPageDatatableOfTransactions; }
            set { _ViewPendingTransactionsPageDatatableOfTransactions = value; }
        }
        private DataTable _ViewPendingTransactionsPageDatatableOfStatus;
        public DataTable ViewPendingTransactionsPageDatatableOfStatus
        {
            get { return _ViewPendingTransactionsPageDatatableOfStatus; }
            set { _ViewPendingTransactionsPageDatatableOfStatus = value; }
        }
        private DataTable _ViewPendingTransactionsPageDatatableUpdateStatus;
        public DataTable ViewPendingTransactionsPageDatatableUpdateStatus
        {
            get { return _ViewPendingTransactionsPageDatatableUpdateStatus; }
            set { _ViewPendingTransactionsPageDatatableUpdateStatus = value; }
        }
        public DataGridView ViewPendingTransactionsPageListOfTransactions
        {
            get { return dataGridView4; }
            set { dataGridView4 = value; }
        }
        public Button ViewPendingTransactionsPageUpdateShippingInfoBtn
        {
            get { return button13; }
            set { button13 = value; }
        }
        public Button ViewPendingTransactionsPageUpdateProductStatusIDBtn
        {
            get { return button14; }
            set { button14 = value; }
        }
        public TextBox ViewPendingTransactionsPageProductManagementIDTxB
        {
            get { return textBox31; }
            set { textBox31 = value; }
        }
        public Label ViewPendingTransactionsPageShippingIdentifier
        {
            get { return label53; }
            set { label53 = value; }
        }
        private int _ViewPendingTransactionsPageShippingID;
        public int ViewPendingTransactionsPageShippingID
        {
            get { return _ViewPendingTransactionsPageShippingID; }
            set { _ViewPendingTransactionsPageShippingID = value; }
        }
        private string _ViewPendingTransactionsPageConnectionString;
        public string ViewPendingTransactionsPageConnectionString
        {
            get { return _ViewPendingTransactionsPageConnectionString; }
            set { _ViewPendingTransactionsPageConnectionString = value; }
        }
        private decimal _ViewPendingTransactionsPageProfits;
        public decimal ViewPendingTransactionsPageProfits
        {
            get { return _ViewPendingTransactionsPageProfits; }
            set { _ViewPendingTransactionsPageProfits = value; }
        }
        private bool _ViewPendingTransactionsPageisRefreshing;
        public bool ViewPendingTransactionsPageisRefreshing
        {
            get { return _ViewPendingTransactionsPageisRefreshing; }
            set { _ViewPendingTransactionsPageisRefreshing = value; }
        }
        private bool _ViewPendingTransactionsPageSearchIsCLicked;
        public bool ViewPendingTransactionsPageSearchIsCLicked
        {
            get { return _ViewPendingTransactionsPageSearchIsCLicked; }
            set { _ViewPendingTransactionsPageSearchIsCLicked = value; }
        }
        private int _ViewPendingTransactionsPageSelectedProductStatusID;
        public int ViewPendingTransactionsPageSelectedProductStatusID
        {
            get { return _ViewPendingTransactionsPageSelectedProductStatusID; }
            set { _ViewPendingTransactionsPageSelectedProductStatusID = value; }
        }
        private int _ViewPendingTransactionsPageUpdateProductStatusID;
        public int ViewPendingTransactionsPageUpdateProductStatusID
        {
            get { return _ViewPendingTransactionsPageUpdateProductStatusID; }
            set { _ViewPendingTransactionsPageUpdateProductStatusID = value; }
        }
        public int _ViewPendingTransactionsPageRetailerID;
        public int ViewPendingTransactionsPageRetailerID
        {
            get { return _ViewPendingTransactionsPageRetailerID; }
            set { _ViewPendingTransactionsPageRetailerID = value; }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            presenter.SetupConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presenter.SignUp();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            presenter.UpdateAccountInfo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            presenter.AddCard();
           
        }

      

        private void button9_Click(object sender, EventArgs e)
        {
            presenter.BrowsePicture();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            presenter.SellItem();
        }

     

        private void button10_Click(object sender, EventArgs e)
        {
            presenter.FilterByProductType();
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            presenter.SignUp();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            presenter.SetupConnection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            presenter.Login();
        }

   

        private void button11_Click(object sender, EventArgs e)
        {
            presenter.SubmitChat();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            presenter.LoadOrdersPage();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            presenter.ChangeToViewMyItems();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            presenter.ReStockItem();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            presenter.BuyItem();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            presenter.UpdateShippingInfo();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            presenter.FilterViewPendingTransactions();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            presenter.UpdateProductStatus();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            presenter.CancelOrder();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            presenter.CalculateTotalPrice();
        }

        private void FrmMainPage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            presenter.RefreshCurrentTab();
        }

        private void dataGridView2_MouseLeave(object sender, EventArgs e)
        {
            DatagridViewMouseLeave = true;
        }

        private void dataGridView4_MouseLeave(object sender, EventArgs e)
        {
            DatagridViewMouseLeave = true;
        }

        private void dataGridView5_MouseLeave(object sender, EventArgs e)
        {
            DatagridViewMouseLeave = true;
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            presenter.InvokeViewAllProductsCellContentClick();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            presenter.ViewProductSellerInfo();
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            presenter.GetCardInfo();
        }

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            presenter.OrdersPageGetSelectedDatarow();
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            presenter.GetShippingAndProductStatus();
        }

        private int _accountID;
        public int accountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }

        public RichTextBox TxtChat
        {
            get { return richTextBox4; }
            set { richTextBox4 = value; }
        }

        private DataTable _ViewAllChatPageDatatables;
        public DataTable ViewAllChatPageDatatable
        {
            get { return _ViewAllChatPageDatatables; }
            set { _ViewAllChatPageDatatables = value; }

        }

        public DataGridView ViewAllChatPageGridview
        {
            get { return dataGridView3; }
            set { dataGridView3 = value; }

        }
        

        private string _ViewAllChatPageConnectionString;
        public string ViewAllChatPageConnectionString
        {
            get { return _ViewAllChatPageConnectionString; }
            set { _ViewAllChatPageConnectionString = value; }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.RemoveCard();
        }

        private void dataGridView3_MouseLeave(object sender, EventArgs e)
        {
            DatagridViewMouseLeave = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            presenter.LogOut();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            presenter.UpdateAccountInfo();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            presenter.RemoveCard();
        }
    }
}
