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
    class ViewAllProductsPageModel
    {
        string Sql;
        Transactions global = new Transactions();


        public DataTable LoadAllProducts(ViewAllProductsPageObject obj)
        {
            global.OpenConnection(obj.ConnectionString);
            Sql = "SELECT\"Group2DB\".\"Product\".\"ProductID\",\"Group2DB\".\"Product\".\"ProductName\",\"Group2DB\".\"Product\".\"ProductDescription\" AS \"Description\"," +
                "\"Group2DB\".\"Product\".\"Stock\",\"Group2DB\".\"Product\".\"RetailerID\" AS \"_RetailerID\"," +
                " \"Group2DB\".\"AccountInfo\".\"FirstName\" AS \"_FirstName\",\"Group2DB\".\"AccountInfo\".\"LastName\" AS \"_LastName\"," +
                " \"Group2DB\".\"ProductType\".\"Description\" AS \"_Description\",\"Group2DB\".\"ProductType\".\"ProductTypeID\" AS \"_ProductTypeID\"," +
                "\"Group2DB\".\"Product\".\"ProductImageLocation\" AS \"_ProductImageLocation\",\"Group2DB\".\"Product\".\"ProductType\" AS \"_ProductType\"," +
                " \"Group2DB\".\"ProductPrice\".\"Price\" AS \"_Price\"" +
                " FROM\"Group2DB\".\"Product\"" +
                "INNER JOIN \"Group2DB\".\"Retailer\" ON \"Group2DB\".\"Product\".\"RetailerID\" = \"Group2DB\".\"Retailer\".\"RetailerID\"" +
                "INNER JOIN \"Group2DB\".\"Account\" ON \"Group2DB\".\"Retailer\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\"" +
                "INNER JOIN \"Group2DB\".\"AccountInfo\" ON \"Group2DB\".\"AccountInfo\".\"AccountID\" = \"Group2DB\".\"Account\".\"AccountID\"" +
                "INNER JOIN \"Group2DB\".\"ProductType\" ON \"Group2DB\".\"Product\".\"ProductType\" = \"Group2DB\".\"ProductType\".\"ProductTypeID\" " +
                "INNER JOIN \"Group2DB\".\"ProductPrice\" ON \"Group2DB\".\"ProductPrice\".\"ProductID\" = \"Group2DB\".\"Product\".\"ProductID\"" +
                " Where\"Group2DB\".\"Product\".\"Stock\" > 0";
            if (obj.ViewAllProductsPageSearchIsCLicked == true)
            {
                if (obj.ViewAllProductsPageProductTypeID != 1)
                {
                    Sql += "AND \"Group2DB\".\"ProductType\".\"ProductTypeID\" = " + obj.ViewAllProductsPageProductTypeID + " ";
                }
             }
                

            return global.Datasource(Sql);
        }


        public DataTable LoadAllMyProducts(ViewAllProductsPageObject obj)
        {
            global.OpenConnection(obj.ConnectionString);
            Sql = " SELECT \"Group2DB\".\"Product\".\"ProductID\"," +
                  "\"Group2DB\".\"Product\".\"ProductName\","+
                  "\"Group2DB\".\"Product\".\"ProductDescription\" AS \"_ProductDescription\"," +
                  "\"Group2DB\".\"Product\".\"Stock\"," +
                  "coalesce(\"SubQuery1\".\"Total Profit\", 0) AS \"Total Profit\"," +
                  "\"Group2DB\".\"AccountInfo\".\"FirstName\" AS \"_FirstName\"," +
                  "\"Group2DB\".\"AccountInfo\".\"LastName\" AS \"_LastName\"," +
                  "\"Group2DB\".\"Product\".\"ProductImageLocation\" AS \"_ProductImageLocation\"" +
                  "FROM" +
                  "\"Group2DB\".\"Retailer\"" +
                  "INNER JOIN \"Group2DB\".\"Product\" ON \"Group2DB\".\"Product\".\"RetailerID\" = \"Group2DB\".\"Retailer\".\"RetailerID\"" +
                  "LEFT JOIN(" +
                  " SELECT" +
                  "\"Group2DB\".\"ProductManagement\".\"ProductID\"," +
                  "SUM(" +
                  "\"Group2DB\".\"ProductManagement\".\"NumberOfPurchased\" * \"Group2DB\".\"ProductPrice\".\"Price\"" +
                  "  ) AS \"Total Profit\"" +
                  " FROM" +
                 "\"Group2DB\".\"ProductManagement\"" +
                 "INNER JOIN \"Group2DB\".\"ProductPrice\" ON \"Group2DB\".\"ProductPrice\".\"ProductID\" = \"Group2DB\".\"ProductManagement\".\"ProductID\"" +
                 "INNER JOIN \"Group2DB\".\"ProductStatus\" ON \"Group2DB\".\"ProductManagement\".\"ProductStatusID\" = \"Group2DB\".\"ProductStatus\".\"ProductStatusID\""+
                 "Where \"Group2DB\".\"ProductStatus\".\"ProductStatusID\" = 4"+
                 "GROUP BY" +
                 "\"Group2DB\".\"ProductManagement\".\"ProductID\"" +
                 ") AS \"SubQuery1\" ON \"Group2DB\".\"Product\".\"ProductID\" = \"SubQuery1\".\"ProductID\"" +
                 "INNER JOIN \"Group2DB\".\"ProductType\" ON \"Group2DB\".\"Product\".\"ProductType\" = \"Group2DB\".\"ProductType\".\"ProductTypeID\"" +
                 "INNER JOIN \"Group2DB\".\"AccountInfo\" ON \"Group2DB\".\"AccountInfo\".\"AccountID\" = \"Group2DB\".\"Retailer\".\"AccountID\""+
                 "WHERE" +
                 "\"Group2DB\".\"Retailer\".\"RetailerID\" = "+  obj.ViewAllProductsPageRetailerID +"";
            if (obj.ViewAllProductsPageSearchIsCLicked == true)
            {
                if (obj.ViewAllProductsPageProductTypeID != 1)
                {
                    Sql += " AND \"Group2DB\".\"ProductType\".\"ProductTypeID\" = " + obj.ViewAllProductsPageProductTypeID + " ";
                }
            }
            Sql += " GROUP BY" +
                    "\"Group2DB\".\"Product\".\"ProductID\"," +
                   "\"Group2DB\".\"Product\".\"ProductName\"," +
                   "\"Group2DB\".\"Product\".\"Stock\"," +
                   "\"SubQuery1\".\"Total Profit\","+
                   "\"Group2DB\".\"AccountInfo\".\"FirstName\","+
                   "\"Group2DB\".\"AccountInfo\".\"LastName\","+
                  "\"Group2DB\".\"Product\".\"ProductImageLocation\"";

            return global.Datasource(Sql);
        }
        public DataTable LoadProductTypes(ViewAllProductsPageObject obj)
        {
            global.OpenConnection(obj.ConnectionString);
            global.startTransaction();
            Sql = "SELECT \"Group2DB\".\"ProductType\".\"ProductTypeID\",\"Group2DB\".\"ProductType\".\"Description\"" +
                "FROM \"Group2DB\".\"ProductType\"";
            return global.Datasource(Sql);
        }
        public void ReStockItem(ViewAllProductsPageObject obj)
        {
            global.OpenConnection(obj.ConnectionString);
            global.startTransaction();
            try
            {
                Sql = "UPDATE \"Group2DB\".\"Product\" SET \"Stock\"="+ obj.ViewAllProductsPageReStock +" WHERE (\"ProductID\"="+ obj.ViewAllProductsPageProductID +")";
                global.Datasource(Sql);
                global.commitQuery();
                global.closeTransaction();
                MessageBox.Show("Successfuly ReStocked");
            }
            catch (Exception e)
            {
                global.rollBackQuery();

                MessageBox.Show(e.Message);
            }


        }
    }
}
