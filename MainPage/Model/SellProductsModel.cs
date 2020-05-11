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
    class SellProductsModel
    {
        string Sql;
        Transactions global = new Transactions();
        DataTable Dt;

     
        public DataTable LoadProductTypes(SellProductsPageObject obj)
        {
            global.OpenConnection(obj.SellProductsPageConnectionString);
            global.startTransaction();
            Sql = "SELECT \"Group2DB\".\"ProductType\".\"ProductTypeID\",\"Group2DB\".\"ProductType\".\"Description\""+
                "FROM \"Group2DB\".\"ProductType\"Where \"Group2DB\".\"ProductType\".\"ProductTypeID\" <> 1";
            return global.Datasource(Sql);
        }

        public void PostItem(SellProductsPageObject obj)
        {
            global.OpenConnection(obj.SellProductsPageConnectionString);
            global.startTransaction();
            try
            {
                Sql = "INSERT INTO \"Group2DB\".\"Product\" (\"ProductName\",\"ProductDescription\",\"Stock\","+
                    "\"ProductType\",\"RetailerID\",\"ProductImageLocation\")"+
                    "VALUES  ( '"+ obj.SellProductsPageProductName +"','"+ obj.SellProductsPageProductDiscription +
                    "',"+ obj.SellProductsPageProductStock +", "+ obj.SellProductsPageProductTypeID +","+
                    obj.SellProductsPageRetailerID+ ", '"+ obj.SellProductsPageImageLocation+
                    "') RETURNING \"ProductID\"";
                Dt = global.Datasource(Sql);

                Sql = "INSERT INTO \"Group2DB\".\"ProductPrice\" (\"ProductID\", \"Price\")VALUES("+ Dt.Rows[0]["ProductID"] +", "+ obj.SellProductsPageProductPrice +")";
                     global.Datasource(Sql);
                global.commitQuery();
                global.closeTransaction();
                MessageBox.Show("Successfuly Saved");
            }
            catch (Exception e)
            {
                global.rollBackQuery();

                MessageBox.Show(e.Message);
            }
        }
    }
}
