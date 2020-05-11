using MainPage.Object;
using OnlineShopping.GlobalTransaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Model
{

 
    class MyAccountPageModel
    {
        Transactions global = new Transactions();
        string sql;
        public DataTable LoadAccountInfo(int accountID,string connectionstring)
        {
            
            global.OpenConnection(connectionstring);
            global.startTransaction();
            sql = "SELECT \"Group2DB\".\"AccountInfo\".\"FirstName\",\"Group2DB\".\"AccountInfo\".\"LastName\",\"Group2DB\".\"AccountInfo\".\"DateOfBirth\","+
                "\"Group2DB\".\"Account\".\"Password\",\"Group2DB\".\"Account\".\"Username\",\"Group2DB\".\"AccountType\".\"Description\",\"Group2DB\".\"AccountType\".\"AccountTypeID\", "+
                " \"Group2DB\".\"Customer\".\"NumberOfPurchase\",\"Group2DB\".\"Retailer\".\"Profits\""+
                "FROM \"Group2DB\".\"Account\" INNER JOIN \"Group2DB\".\"AccountInfo\" ON \"Group2DB\".\"AccountInfo\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\""+
                "INNER JOIN \"Group2DB\".\"AccountType\" ON \"Group2DB\".\"AccountInfo\".\"AccountTypeID\" = \"Group2DB\".\"AccountType\".\"AccountTypeID\"" +
                "FULL OUTER JOIN \"Group2DB\".\"Customer\" ON \"Group2DB\".\"Customer\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\""+
                "full outer JOIN \"Group2DB\".\"Retailer\" ON \"Group2DB\".\"Retailer\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\""+
                " where \"Group2DB\".\"Account\".\"AccountID\" = " + accountID + "";
            return global.Datasource(sql);
        }
        public DataTable GetlistOfCards(int accountID, string connectionstring)
        {
            global.OpenConnection(connectionstring);
            global.startTransaction();

            sql = "SELECT \"Group2DB\".\"CustomerCardInfo\".\"CardID\",\"Group2DB\".\"CustomerCardInfo\".\"CardNumber\",\"Group2DB\".\"CustomerCardInfo\".\"SecurityCode\",\"Group2DB\".\"CustomerCardInfo\".\"Balance\" " +
               " " +" FROM\"Group2DB\".\"Account\"INNER JOIN \"Group2DB\".\"Customer\" ON \"Group2DB\".\"Customer\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\" "+
               " " + "INNER JOIN \"Group2DB\".\"CustomerCardInfo\" ON \"Group2DB\".\"CustomerCardInfo\".\"CustomerID\" = \"Group2DB\".\"Customer\".\"CustomerID\" "+
               " " + "WHERE\"Group2DB\".\"Account\".\"AccountID\" = " + accountID;


                  return global.Datasource(sql);
        }

        public void UpdateAccountInfo(MyAccountPageObject obj)
        {
            global.OpenConnection(obj.MyAccountPageConnectionString);
            global.startTransaction();
            try
            {
              
                sql = "UPDATE \"Group2DB\".\"AccountInfo\"SET \"FirstName\" = '"+obj.MyAccountPageFirstName +"',\"LastName\" = '"+ obj.MyAccountPageLastName +"',\"DateOfBirth\" = '"+ obj.MyAccountPageDateOfBirth.Date+ " ' "+
                " " + "WHERE \"AccountID\" =  " + ""+ obj.MyAccountPageAccountID + "";  
                global.Datasource(sql);
                sql = "UPDATE \"Group2DB\".\"Account\" SET \"Username\" = '" + obj.MyAccountPageUsername + "'," +
                    " \"Password\"='" + obj.MyAccountPagePassword + "' WHERE(\"AccountID\" = "+ obj.MyAccountPageAccountID +")";
                global.Datasource(sql);
                global.commitQuery();
                global.closeTransaction();
                MessageBox.Show("Sucessfully Updated Profile");
            }
            catch (Exception e)
            {
                global.rollBackQuery();

                MessageBox.Show(e.Message);
            }         
        }

        public void AddCard(MyAccountPageObject obj)
        {
            global.OpenConnection(obj.MyAccountPageConnectionString);
            global.startTransaction();
            try
            {

                sql = "INSERT INTO \"Group2DB\".\"CustomerCardInfo\" (\"CustomerID\",\"CardNumber\",\"SecurityCode\",\"Balance\")" +
                    " VALUES (" + obj.MyAccountPageCustomerID + ", " + obj.MyAccountPageCardNumber + "," + obj.MyAccountPageSecurityCode + " ," + obj.MyAccountPageBalance + ") ";
                global.Datasource(sql);
                global.commitQuery();
                global.closeTransaction();
            }
            catch (Exception e)
            {
                global.rollBackQuery();

                MessageBox.Show(e.Message + "CardNumber is already taken");
            }
        }
        public void RemoveCard(MyAccountPageObject obj)
        {
            global.OpenConnection(obj.MyAccountPageConnectionString);
            global.startTransaction();
            try
            {

                sql = "Delete from \"Group2DB\".\"CustomerCardInfo\" where \"Group2DB\".\"CustomerCardInfo\".\"CardID\" =" + ""+ obj.MyAccountPageRemoveCardSelectedID +"";
                global.Datasource(sql);
                global.commitQuery();
                global.closeTransaction();
                MessageBox.Show("Card Deleted");
            }
            catch (Exception e)
            {
                global.rollBackQuery();

                MessageBox.Show(e.Message + "CardNumber is already taken");
            }
        }


    }
   
}
