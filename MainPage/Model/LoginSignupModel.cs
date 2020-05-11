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
    class LoginSignupModel
    {
        string Sql;
        Transactions global = new Transactions();
        DataTable Dt;

   

        public Boolean SignUp(LoginSignUpObject obj)
        {
            string ConnectionString = "Server=localhost;Port=5432; User Id=postgres;Password=postgres; Database=postgres;";
            global.OpenConnection(ConnectionString);
            global.startTransaction();
            try
            {
                string str1 = obj.SingupDateOfBirth.Date.Date.ToString("yyyy-MM-dd");
                Sql = "INSERT INTO  \"Group2DB\".\"Account\"(\"Username\", \"Password\")VALUES('" + obj.SignUpUsername + "','" + obj.SignUpPassword + "')RETURNING \"AccountID\";";
                Dt = global.Datasource(Sql);
                Sql = "INSERT INTO  \"Group2DB\".\"AccountInfo\" (\"AccountTypeID\", \"AccountID\",\"FirstName\",\"LastName\",\"DateOfBirth\") VALUES(" + obj.AccountTypeID + "," + Dt.Rows[0]["AccountID"] + ",'" + obj.SignupFirstName + "','" +
                    obj.SingupLastName + "','" + str1 + "')";
                global.Datasource(Sql);

                if (obj.AccountTypeID == 0)//retailer
                {
                    Sql = "INSERT INTO \"Group2DB\".\"Customer\" (\"AccountID\",\"NumberOfPurchase\")" +
                    " " + " VALUES (" + Dt.Rows[0]["AccountID"] + ",0)";
                  
                }
                else
                {
                    Sql = "INSERT INTO \"Group2DB\".\"Retailer\" (\"AccountID\",\"Profits\")" +
                   " " + " VALUES (" + Dt.Rows[0]["AccountID"] + ",0)";

                }
                global.Datasource(Sql);
                global.commitQuery();
                global.closeTransaction();
                return true;
            }
            catch (Exception e)
            {
                global.rollBackQuery();
                MessageBox.Show(e.Message + "Username is Already Taken");
                global.closeTransaction();
                return false;
            }
         }

        public DataTable Login(LoginSignUpObject obj, string ConnectionString)
        {
            global.OpenConnection(ConnectionString);
            global.startTransaction();
            Sql = "SELECT\"Group2DB\".\"Account\".\"AccountID\",\"Group2DB\".\"Account\".\"Username\",\"Group2DB\".\"Account\".\"Password\","+
                " "+ "\"Group2DB\".\"Retailer\".\"RetailerID\",\"Group2DB\".\"Customer\".\"CustomerID\",\"Group2DB\".\"AccountType\".\"AccountTypeID\""+
                " "+ "FROM\"Group2DB\".\"Account\""+
                " "+ "FULL OUTER JOIN \"Group2DB\".\"Retailer\" ON \"Group2DB\".\"Retailer\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\""+
                " "+ "FULL OUTER JOIN \"Group2DB\".\"Customer\" ON \"Group2DB\".\"Customer\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\""+
                " " + "INNER JOIN \"Group2DB\".\"AccountInfo\" ON \"Group2DB\".\"AccountInfo\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\"" +
                " " + "INNER JOIN \"Group2DB\".\"AccountType\" ON \"Group2DB\".\"AccountInfo\".\"AccountTypeID\" = \"Group2DB\".\"AccountType\".\"AccountTypeID\"";
                 return global.Datasource(Sql);
              
        }

        public DataTable LoadAccountTypes()
        {
            string ConnectionString = "Server=localhost;Port=5432; User Id=postgres;Password=postgres; Database=postgres;";
            global.OpenConnection(ConnectionString);
            global.startTransaction();
            Sql = "Select \"AccountType\".\"AccountTypeID\", \"AccountType\".\"Description\" FROM \"Group2DB\".\"AccountType\" ";
            return global.Datasource(Sql);
        }

    }
}
