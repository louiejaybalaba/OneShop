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
    
    class BuyItemsPageModel
    {
        Transactions global = new Transactions();
        DataTable Dt = new DataTable();
        string Sql;
        public void BuySelectedProduct(BuyItemsPageObject obj)
        {
            global.OpenConnection(obj.ViewAllProductsPageConnectionString);
            global.startTransaction();
            try
            {     
                Sql = "INSERT INTO \"Group2DB\".\"ProductManagement\" (\"ProductID\",\"CustomerID\",\"ProductStatusID\",\"NumberOfPurchased\")"+
                    "VALUES ("+ obj.BuyItemsPageProductID +", "+ obj.BuyItemsPageProductCustomerID + ",2, "+ obj.BuyItemsPageProductNumberOfPurcahsed+ ") RETURNING \"ProductManagementID\"";

                Dt = global.Datasource(Sql);

                Sql = "UPDATE \"Group2DB\".\"CustomerCardInfo\" SET \"Balance\"="+ obj.BuyItemsPageProductSelectedCardBalance +" WHERE (\"CardID\"="+ obj.BuyItemsPageProductSelectedCardID +")";
                global.Datasource(Sql);

                Sql = "UPDATE \"Group2DB\".\"Product\" SET \"Stock\"="+ obj.BuyItemsPageStock +" WHERE (\"ProductID\"="+ obj.BuyItemsPageProductID +")";
                global.Datasource(Sql);

                string str = "CURRENT_TIMESTAMP";
                Sql = "INSERT INTO \"Group2DB\".\"ProductTimePurchased\" (\"ProductManagementID\", \"TimePurchased\") VALUES ("+ Dt.Rows[0]["ProductManagementID"] +", " + str + ")";
                global.Datasource(Sql);

               Sql = " INSERT INTO \"Group2DB\".\"ProductShippment\"(\"ProductManagementID\", \"ShippingAddress\") VALUES(" + Dt.Rows[0]["ProductManagementID"] + ", '"+ obj.BuyItemsPageShippingAddress +"')";
                global.Datasource(Sql);
                global.commitQuery();

                global.closeTransaction();
                MessageBox.Show("Successfuly Purchased The Item");
            }
            catch (Exception e)
            {
                global.rollBackQuery();

                MessageBox.Show(e.Message);
            }
        }

    }
}
