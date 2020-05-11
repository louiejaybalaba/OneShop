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
    class ChatBoxModel
    {
        string Sql;
        Transactions global = new Transactions();
        DataTable Dt;

        public void submitChat(ChatBoxPageObject obj)
        {
           
            global.OpenConnection(obj.connectionString);
            global.startTransaction();
            try
            {
                string str = "CURRENT_TIMESTAMP";
                string sql = "INSERT INTO \"Group2DB\".\"ChatBox\" (\"AccountID\", \"Chat\", \"DateTimePosted\") VALUES ('" + obj.accountID + "', '" + obj.txtChat + "'," + str +") ";
                global.Datasource(sql);
                global.commitQuery();
                global.closeTransaction();
            }
            catch (Exception e)
            {
                global.closeTransaction();
                MessageBox.Show(e.Message+ "Cannot Submit This Time");
            }
        }

        public DataTable ViewAllChat(ChatBoxPageObject obj)
        {
          
            global.OpenConnection(obj.connectionString);
            global.startTransaction();

                Sql = "SELECT \"Group2DB\".\"Account\".\"Username\",\"Group2DB\".\"ChatBox\".\"Chat\",\"Group2DB\".\"ChatBox\".\"DateTimePosted\"" +
                    "FROM\"Group2DB\".\"ChatBox\"INNER JOIN \"Group2DB\".\"Account\" ON \"Group2DB\".\"ChatBox\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\"";

                return global.Datasource(Sql);
        }

        //public int getAccountID(int accountID)
        //{
        //    string ConnectionString = "Server=localhost;Port=5432; User Id=postgres;Password=root; Database=postgres;";
        //    global.OpenConnection(ConnectionString);
        //    global.startTransaction();
        //    DataTable dt = new DataTable();
        //    string sql;
        //    sql = "SELECT \"Group2DB\".\"Account\".\"AccountID\" FROM \"Group2DB\".\"Account\" WHERE\"Account\".\"AccountID\" = '" + accountID + "'";

        //    dt = global.Datasource(sql);

        //    return Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
        //}


    }
}
