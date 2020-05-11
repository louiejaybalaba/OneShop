using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Object
{
    class MyAccountPageObject
    {
        public string MyAccountPageUsername ;
        public string MyAccountPagePassword ;
        public string MyAccountPageAccountType ;
        public string MyAccountPageFirstName ;
        public string MyAccountPageLastName ;
        public string MyAccountPageCardNumber ;
        public string MyAccountPageSecurityCode ;
        public string MyAccountPageBalance ;

        public DataTable MyAccountPageDatatableOfCards ;

        public  DateTime MyAccountPageDateOfBirth ;

         public string MyAccountPageConnectionString ;

        public int MyAccountPageAccountTypeID ;
        public int MyAccountPageRemoveCardSelectedID;
        public int MyAccountPageAccountID ;
        public int MyAccountPageRetailerID ;
        public int MyAccountPageCustomerID ;

    }
}
