using OnlineShopping.GlobalTransaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Model
{
    

    class modcclass
    {
        string Sql;
        Transactions global = new Transactions();
        DataTable Dt;
        public DataTable getAcc()
        {

            global.OpenConnection(connectionstring);
            global.startTransaction();

            Sql = "SELECT * FROM \"Group2DB\".\"Account\"";


            return global.Datasource(sql);
        }

    }

  
}
