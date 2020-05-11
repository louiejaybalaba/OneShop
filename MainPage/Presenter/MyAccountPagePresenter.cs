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
    class MyAccountPagePresenter
    {

        MyAccountPageModel mod = new MyAccountPageModel();
        MyAccountPageObject obj = new MyAccountPageObject();
        MyAccountPageInterface MyAccountPageView;
        DataGridViewButtonColumn RemoveCard;
        DataTable Dt;

        public MyAccountPagePresenter(MyAccountPageInterface IMyAccountPageView)
        {
            MyAccountPageView = IMyAccountPageView;

            MyAccountPageView.MyAccountPageProfitsNumberOfPurchase.ReadOnly = true;
            MyAccountPageView.MyAccountPageAccountTypeTxB.ReadOnly = true;
          
        }

   

        public void LoadAccountInfo()
        {


            Dt = mod.LoadAccountInfo(MyAccountPageView.MyAccountPageAccountID, MyAccountPageView.MyAccountPageConnectionString);
            MyAccountPageView.MyAccountPageAccountTypeID = Convert.ToInt32(Dt.Rows[0]["AccountTypeID"].ToString());
            MyAccountPageView.MyAccountPageAccountTypeTxB.Text = Dt.Rows[0]["Description"].ToString();
            MyAccountPageView.MyAccountPageUsernameTxB.Text = Dt.Rows[0]["Username"].ToString();
            MyAccountPageView.MyAccountPagePasswordTxB.Text = Dt.Rows[0]["Password"].ToString();
            MyAccountPageView.MyAccountPageFirstNameTxB.Text = Dt.Rows[0]["FirstName"].ToString();
            MyAccountPageView.MyAccountPageLastNameTxB.Text = Dt.Rows[0]["LastName"].ToString();
            MyAccountPageView.MyAccountPageDateOfBirthDTP.Value = Convert.ToDateTime(Dt.Rows[0]["DateOfBirth"].ToString());

            if (MyAccountPageView.MyAccountPageAccountTypeID == 0)
            {

                
                MyAccountPageView.MyAccountPageProfitsNumberOfPurchase.Text = Dt.Rows[0]["NumberOfPurchase"].ToString();
                LoadCardInfo();
                MyAccountPageView.MyAccountPageProfitsNumberOfPurchase.Text = "Number Of Purchase";
                MyAccountPageView.MyAccountPageCardInfo.Show();
            }
            else
            {
                MyAccountPageView.MyAccountPageProfitsNumberOfPurchase.Text = Dt.Rows[0]["Profits"].ToString();
                MyAccountPageView.MyAccountPageCardInfo.Hide();
                MyAccountPageView.MyAccountPageProfitsNumberOfPurchase.Text = "Profits";
            }
        }
    

        public void LoadCardInfo()
        {

            MyAccountPageView.MyAccountPageDatatableOfCards = mod.GetlistOfCards(MyAccountPageView.MyAccountPageAccountID, MyAccountPageView.MyAccountPageConnectionString);          
            MyAccountPageView.MyAccountPageListOfCards.DataSource = MyAccountPageView.MyAccountPageDatatableOfCards;
        }
        

        public void UpdateAccountInfo()
        {
            Dt = MyAccountPageView.MyAccountPageDatatableOfCards;

            obj.MyAccountPageUsername = MyAccountPageView.MyAccountPageUsernameTxB.Text;
            obj.MyAccountPagePassword = MyAccountPageView.MyAccountPagePasswordTxB.Text;
            obj.MyAccountPageFirstName = MyAccountPageView.MyAccountPageFirstNameTxB.Text;
            obj.MyAccountPageLastName = MyAccountPageView.MyAccountPageLastNameTxB.Text;
            obj.MyAccountPageDateOfBirth = MyAccountPageView.MyAccountPageDateOfBirthDTP.Value;
            obj.MyAccountPageConnectionString = MyAccountPageView.MyAccountPageConnectionString;
            obj.MyAccountPageAccountID = MyAccountPageView.MyAccountPageAccountID;
            mod.UpdateAccountInfo(obj);

        }

        public void AddCard()
        {
            obj.MyAccountPageCardNumber = MyAccountPageView.MyAccountPageCardNumberTxB.Text;
            obj.MyAccountPageSecurityCode = MyAccountPageView.MyAccountPageSecurityCodeTxB.Text;
            obj.MyAccountPageBalance = MyAccountPageView.MyAccountPageBalanceTxB.Text;
            obj.MyAccountPageConnectionString = MyAccountPageView.MyAccountPageConnectionString;
            obj.MyAccountPageCustomerID = MyAccountPageView.MyAccountPageCustomerID;
            mod.AddCard(obj);
   
        }
        public void RemoveCardInfo()
        {
            
            DataRow dr = MyAccountPageView.MyAccountPageDatatableOfCards.Rows[MyAccountPageView.MyAccountPageListOfCards.CurrentCell.RowIndex];
            obj.MyAccountPageRemoveCardSelectedID = Int32.Parse(dr["CardID"].ToString());
            obj.MyAccountPageConnectionString = MyAccountPageView.MyAccountPageConnectionString;
            MyAccountPageView.MyAccountPageDatatableOfCards.Rows.RemoveAt(MyAccountPageView.MyAccountPageListOfCards.CurrentCell.RowIndex);
            mod.RemoveCard(obj);
        }

    }
}
