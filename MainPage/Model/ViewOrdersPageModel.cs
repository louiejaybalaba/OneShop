using MainPage.Object;
using OnlineShopping.GlobalTransaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Model
{
    class ViewOrdersPageModel
    {
        string Sql;
        Transactions global = new Transactions();
        public DataTable LoadAllMyOrders(ViewOrdersPageObject obj)
        {
            global.OpenConnection(obj.ViewOrdersPageConnectionString);
            global.startTransaction();
            Sql = "SELECT" +
                    "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\"," +
                    "\"Group2DB\".\"ProductManagement\".\"ProductID\" AS \"_ProductID\"," +
                    "\"Group2DB\".\"Product\".\"ProductName\"," +
                    "\"Subquery\".\"Price\"," +
                    "\"Group2DB\".\"ProductManagement\".\"NumberOfPurchased\"," +
                    "\"Subquery\".\"Total Price\"," +
                    "\"Group2DB\".\"ProductShippment\".\"ShippingAddress\"," +
                    "\"Group2DB\".\"ProductShippment\".\"ShippingDate\"," +
                    "\"Group2DB\".\"ProductShippment\".\"DeliveryDate\"," +
                    "\"Group2DB\".\"ProductTimePurchased\".\"TimePurchased\"," +
                    "\"Group2DB\".\"ProductStatus\".\"Description\"," +
                    "\"Group2DB\".\"ProductManagement\".\"ProductStatusID\" AS \"_ProductStatusID\"" +
                    "FROM" +
                    "\"Group2DB\".\"ProductManagement\"" +
                    "INNER JOIN \"Group2DB\".\"Product\" ON \"Group2DB\".\"ProductManagement\".\"ProductID\" = \"Group2DB\".\"Product\".\"ProductID\"" +
                    "INNER JOIN \"Group2DB\".\"ProductPrice\" ON \"Group2DB\".\"ProductPrice\".\"ProductID\" = \"Group2DB\".\"Product\".\"ProductID\"" +
                    "INNER JOIN(" +
                    " SELECT" +
                    "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\"," +
                    "\"Group2DB\".\"ProductPrice\".\"Price\"," +
                    "SUM(" +
                    "\"Group2DB\".\"ProductManagement\".\"NumberOfPurchased\" * \"Group2DB\".\"ProductPrice\".\"Price\"" +
                    ") AS \"Total Price\"" +
                    "FROM" +
                    "\"Group2DB\".\"ProductManagement\"" +
                    " INNER JOIN \"Group2DB\".\"ProductPrice\" ON \"Group2DB\".\"ProductPrice\".\"ProductID\" = \"Group2DB\".\"ProductManagement\".\"ProductID\"" +
                    " GROUP BY" +
                    "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\"," +
                    " \"Group2DB\".\"ProductPrice\".\"Price\"" +
                    ") AS \"Subquery\" ON \"Group2DB\".\"ProductManagement\".\"ProductManagementID\" = \"Subquery\".\"ProductManagementID\"" +
                    "INNER JOIN \"Group2DB\".\"ProductShippment\" ON \"Group2DB\".\"ProductShippment\".\"ProductManagementID\" = \"Group2DB\".\"ProductManagement\".\"ProductManagementID\"" +
                    "INNER JOIN \"Group2DB\".\"ProductTimePurchased\" on \"Group2DB\".\"ProductManagement\".\"ProductManagementID\" = \"Group2DB\".\"ProductTimePurchased\".\"ProductManagementID\" " +
                    "INNER JOIN \"Group2DB\".\"ProductStatus\" ON \"Group2DB\".\"ProductManagement\".\"ProductStatusID\" = \"Group2DB\".\"ProductStatus\".\"ProductStatusID\"" +
                    "Where \"Group2DB\".\"ProductManagement\".\"CustomerID\" = " + obj.ViewOrdersPageCustomerID + "";


                    if (obj.ViewOrdersPageSearchButtonIsClicked == true && obj.ViewOrdersPageSelectedStatus !=1 )
                    {
                    Sql += " AND \"Group2DB\".\"ProductManagement\".\"ProductStatusID\" = "+ obj.ViewOrdersPageSelectedStatus +"";
                    }
                    Sql += " ORDER BY" +
                    "\"Group2DB\".\"ProductManagement\".\"ProductManagementID\" ASC";

            return global.Datasource(Sql);
        }

        public DataTable LoadAlProductStatus(ViewOrdersPageObject obj)
        {
            global.OpenConnection(obj.ViewOrdersPageConnectionString);
            global.startTransaction();
            Sql = "SELECT"+
                  " \"Group2DB\".\"ProductStatus\".\"Description\","+
                  " \"Group2DB\".\"ProductStatus\".\"ProductStatusID\""+
                  "FROM"+
                    "\"Group2DB\".\"ProductStatus\"";
            return global.Datasource(Sql);
        }

        public void CancelOrder(ViewOrdersPageObject obj)
        {
            global.OpenConnection(obj.ViewOrdersPageConnectionString);
            global.startTransaction();
            try
            {
                Sql = "UPDATE \"Group2DB\".\"ProductManagement\" SET \"ProductStatusID\"='5' WHERE (\"ProductManagementID\"="+ obj.ViewOrdersPageProductManagementID +")";
                global.Datasource(Sql);
                DataTable Dt;
                int stock;
                Sql = "SELECT \"Group2DB\".\"Product\".\"Stock\" FROM \"Group2DB\".\"Product\"" +
                    "WHERE \"Group2DB\".\"Product\".\"ProductID\" =  " + obj.ViewOrdersPageProductID + "";
                Dt = global.Datasource(Sql);
                stock = int.Parse(Dt.Rows[0]["Stock"].ToString());
                stock += obj.ViewOrdersPagerNumberOfPurchased;
                Sql = "UPDATE \"Group2DB\".\"Product\" SET \"Stock\"=" + stock + " WHERE (\"ProductID\"=" + obj.ViewOrdersPageProductID + ")";
                global.Datasource(Sql);

                global.commitQuery();
                global.closeTransaction();
            }
            catch (Exception e)
            {
                global.rollBackQuery();
            }
        }
    }
}
