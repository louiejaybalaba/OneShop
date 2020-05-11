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
    class ViewPendingTransactionsPageModel
    {
        Transactions global = new Transactions();

        string Sql;
        public DataTable RetrieveProductStatus(ViewPendingTransactionsPageObject obj)
        {
            global.OpenConnection(obj.ViewPendingTransactionsPageConnectionString);
            global.startTransaction();
            Sql = "SELECT\"Group2DB\".\"ProductStatus\".\"Description\",\"Group2DB\".\"ProductStatus\".\"ProductStatusID\""+
                   "FROM\"Group2DB\".\"ProductStatus\"";
            return global.Datasource(Sql);
        }

        public DataTable RetrieveProductStatusUpdate(ViewPendingTransactionsPageObject obj)
        {
            global.OpenConnection(obj.ViewPendingTransactionsPageConnectionString);
            global.startTransaction();
            Sql = "SELECT\"Group2DB\".\"ProductStatus\".\"Description\",\"Group2DB\".\"ProductStatus\".\"ProductStatusID\"" +
                   "FROM\"Group2DB\".\"ProductStatus\"";
            return global.Datasource(Sql);
        }


        public DataTable RetrieveAllTransactions(ViewPendingTransactionsPageObject obj)
        {
            global.OpenConnection(obj.ViewPendingTransactionsPageConnectionString);
            global.startTransaction();
            Sql = "SELECT" +
                "\"Group2DB\".\"AccountInfo\".\"FirstName\" || ' ' || \"Group2DB\".\"AccountInfo\".\"LastName\" AS \"Buyer Name\","+
                "\"Group2DB\".\"Product\".\"ProductName\"," +
                  "\"Group2DB\".\"ProductStatus\".\"ProductStatusID\" AS \"_ProductStatusID\",\"Group2DB\".\"ProductManagement\".\"NumberOfPurchased\"," +
                   "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\" AS \"_ProductManagementID\",\"SubQuery\".\"Total\"," +
                   "\"SubQuery\".\"TimePurchased\" AS \"Date and Time Purchased\"," +
                   " \"SubQuery2\".\"ShippingID\" AS \"_ShippingID\"," +
                   "\"SubQuery2\".\"ShippingDate\" AS \"_ShippingDate\"," +
                   "\"SubQuery2\".\"DeliveryDate\" AS \"_DeliveryDate\"," +
                   "\"Group2DB\".\"ProductStatus\".\"ProductStatusID\" AS \"_ProductStatusID\"," +
                   "\"Group2DB\".\"ProductStatus\".\"Description\" AS \"Status\"," +
                   "\"Group2DB\".\"Customer\".\"CustomerID\" AS \"_CustomerID\"," +
                   "\"Group2DB\".\"Customer\".\"NumberOfPurchase\" AS \"_CustomerNumberOfPurchased\"," +
                   "\"Group2DB\".\"Product\".\"ProductID\" AS \"_ProductID\"" +
                 " FROM" +
                "\"Group2DB\".\"Retailer\"" +
                "INNER JOIN \"Group2DB\".\"Product\" ON \"Group2DB\".\"Product\".\"RetailerID\" = \"Group2DB\".\"Retailer\".\"RetailerID\"" +
                "INNER JOIN \"Group2DB\".\"ProductManagement\" ON \"Group2DB\".\"ProductManagement\".\"ProductID\" = \"Group2DB\".\"Product\".\"ProductID\"" +
                "INNER JOIN \"Group2DB\".\"ProductStatus\" ON \"Group2DB\".\"ProductManagement\".\"ProductStatusID\" = \"Group2DB\".\"ProductStatus\".\"ProductStatusID\"" +
                "INNER JOIN \"Group2DB\".\"Customer\" ON \"Group2DB\".\"Customer\".\"CustomerID\" = \"Group2DB\".\"ProductManagement\".\"CustomerID\""+
                "INNER JOIN \"Group2DB\".\"AccountInfo\" ON \"Group2DB\".\"AccountInfo\".\"AccountID\" = \"Group2DB\".\"Customer\".\"AccountID\""+
                "INNER JOIN \"Group2DB\".\"ProductType\" ON \"Group2DB\".\"Product\".\"ProductType\" = \"Group2DB\".\"ProductType\".\"ProductTypeID\"" +
                "INNER JOIN(" +
                "SELECT" +
                "(" +
                "\"Group2DB\".\"ProductManagement\".\"NumberOfPurchased\" * \"Group2DB\".\"ProductPrice\".\"Price\"" +
                ") AS \"Total\"," +
                "\"Group2DB\".\"ProductTimePurchased\".\"TimePurchased\"," +
                "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\"" +
  
                "FROM" +
                "\"Group2DB\".\"ProductManagement\"" +
                "INNER JOIN \"Group2DB\".\"ProductPrice\" ON \"Group2DB\".\"ProductPrice\".\"ProductID\" = \"Group2DB\".\"ProductManagement\".\"ProductID\"" +
                "INNER JOIN \"Group2DB\".\"ProductTimePurchased\" ON \"Group2DB\".\"ProductTimePurchased\".\"ProductManagementID\" = \"Group2DB\".\"ProductManagement\".\"ProductManagementID\""+
                "INNER JOIN \"Group2DB\".\"CustomerCardInfo\" ON \"Group2DB\".\"CustomerCardInfo\".\"CustomerID\" = \"Group2DB\".\"ProductManagement\".\"CustomerID\""+
                "GROUP BY" +
                "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\"," +
 
                "\"Group2DB\".\"ProductTimePurchased\".\"TimePurchased\"," +
                "\"Total\"" +
                ") AS \"SubQuery\" ON \"Group2DB\".\"ProductManagement\".\"ProductManagementID\" = \"SubQuery\".\"ProductManagementID\"" +
                "LEFT JOIN (SELECT"+
                "\"Group2DB\".\"ProductShippment\".\"DeliveryDate\"," +
                "\"Group2DB\".\"ProductShippment\".\"ShippingDate\"," +
                "\"Group2DB\".\"ProductShippment\".\"ShippingID\"," +
                "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\"" +
                "FROM" +
                "\"Group2DB\".\"ProductShippment\"" +
                "INNER JOIN \"Group2DB\".\"ProductManagement\" ON \"Group2DB\".\"ProductShippment\".\"ProductManagementID\" = \"Group2DB\".\"ProductManagement\".\"ProductManagementID\"" +
                "GROUP BY \"Group2DB\".\"ProductManagement\".\"ProductManagementID\"," +    
                "\"Group2DB\".\"ProductShippment\".\"ShippingID\"," +
                "\"Group2DB\".\"ProductShippment\".\"DeliveryDate\"," +
                "\"Group2DB\".\"ProductShippment\".\"ShippingDate\")" +
                "AS  \"SubQuery2\" ON \"Group2DB\".\"ProductManagement\".\"ProductManagementID\" = \"SubQuery2\".\"ProductManagementID\"" +
                "Where \"Group2DB\".\"Product\".\"RetailerID\" = " + obj.ViewPendingTransactionsPageRetailerID +"";

            if (obj.ViewPendingTransactionsPageSearchIsCLicked == true)
            {
                if (obj.ViewPendingTransactionsPageSelectedProductStatusID != 1)
                {
                    Sql += "AND \"Group2DB\".\"ProductManagement\".\"ProductStatusID\" = " + obj.ViewPendingTransactionsPageSelectedProductStatusID + " ";
                }
            }

            return global.Datasource(Sql);
        }

        public bool UpdateShippingInfo(ViewPendingTransactionsPageObject obj)
        {
            bool success = false;
            global.OpenConnection(obj.ViewPendingTransactionsPageConnectionString);
            global.startTransaction();
            try
            {
                string str1 = obj.ViewPendingTransactionsPageShippingDate.Date.ToString("yyyy-MM-dd");
                string str2 = obj.ViewPendingTransactionsPageDeilveryDate.Date.ToString("yyyy-MM-dd");


                Sql = "UPDATE \"Group2DB\".\"ProductShippment\" SET \"ShippingDate\"='" + str1 +"', \"DeliveryDate\"='"+ str2 +"'"+
                    "WHERE (\"ShippingID\"="+ obj.ViewPendingTransactionsPageShippingID +")";
                global.Datasource(Sql);
                Sql = "UPDATE \"Group2DB\".\"ProductManagement\" SET \"ProductStatusID\"='3' WHERE (\"ProductManagementID\"="+ obj.ViewPendingTransactionsPageProductManagementID +")";
                global.Datasource(Sql);
                global.commitQuery();
                global.closeTransaction();
                success = true;
                MessageBox.Show("Success Updating ShippingInfo");
            }
            catch (Exception e)
            {
                global.rollBackQuery();
                MessageBox.Show(e.Message);

            }
            return success;

        }

        public void UpdateProductStatus(ViewPendingTransactionsPageObject obj)
        {
            DataTable Dt;
            global.OpenConnection(obj.ViewPendingTransactionsPageConnectionString);
            global.startTransaction();
            try
            {
                Sql = "UPDATE \"Group2DB\".\"ProductManagement\" SET \"ProductStatusID\"="+ obj.ViewPendingTransactionsPageSelectedProductStatusID +" WHERE (\"ProductManagementID\"=" + obj.ViewPendingTransactionsPageProductManagementID + ")";
                global.Datasource(Sql);

                if (obj.ViewPendingTransactionsPageSelectedProductStatusID == 4)
                {

                    Sql = "SELECT\"Group2DB\".\"Retailer\".\"Profits\" FROM \"Group2DB\".\"Retailer\"";
                
                    Dt = global.Datasource(Sql);
                    obj.ViewPendingTransactionsPageUpdateProfits += decimal.Parse(Dt.Rows[0]["Profits"].ToString());
                    Sql = "UPDATE \"Group2DB\".\"Retailer\" SET \"Profits\" = " + obj.ViewPendingTransactionsPageUpdateProfits + " WHERE (\"RetailerID\"=" + obj.ViewPendingTransactionsPageRetailerID + ")";
                    global.Datasource(Sql);
                    Sql = "UPDATE \"Group2DB\".\"Customer\" SET \"NumberOfPurchase\"=" + obj.ViewPendingTransactionsPageCustomerNumberOfPurchased + " WHERE (\"CustomerID\"=" + obj.ViewPendingTransactionsPageCustomerID + ")";
                    global.Datasource(Sql);


                }
                else if (obj.ViewPendingTransactionsPageSelectedProductStatusID == 5) /*' e uli inig ma cancel'*/
                {            
                    int stock;               
                    Sql = "SELECT \"Group2DB\".\"Product\".\"Stock\" FROM \"Group2DB\".\"Product\"" +
                        "WHERE \"Group2DB\".\"Product\".\"ProductID\" =  " + obj.ViewPendingTransactionsPageProductID + "";
                    Dt = global.Datasource(Sql);
                    stock = int.Parse(Dt.Rows[0]["Stock"].ToString());
                    stock += obj.ViewPendingTransactionsPageCustomerNumberOfPurchased;
                    Sql = "UPDATE \"Group2DB\".\"Product\" SET \"Stock\"=" + stock + " WHERE (\"ProductID\"=" + obj.ViewPendingTransactionsPageProductID + ")";
                    global.Datasource(Sql);
                }

                global.commitQuery();
                global.closeTransaction();
                MessageBox.Show("Success Updating ");
            }
            catch (Exception e)
            {
                global.rollBackQuery();

            }
        }
        }
    }

