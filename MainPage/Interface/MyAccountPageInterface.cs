using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface MyAccountPageInterface
    {

        TextBox MyAccountPageUsernameTxB { get; set; }
        TextBox MyAccountPagePasswordTxB { get; set; }
        TextBox MyAccountPageAccountTypeTxB { get; set; }
        TextBox MyAccountPageFirstNameTxB { get; set; }
        TextBox MyAccountPageLastNameTxB { get; set; }
        TextBox MyAccountPageProfitsNumberOfPurchase { get; set; }
        TextBox MyAccountPageCardNumberTxB { get; set; }
        TextBox MyAccountPageSecurityCodeTxB { get; set; }
        TextBox MyAccountPageBalanceTxB { get; set; }



        DataGridView MyAccountPageListOfCards { get; set; }

        DataTable MyAccountPageDatatableOfCards { get; set; }

        DateTimePicker MyAccountPageDateOfBirthDTP { get; set; }

        Panel MyAccountPageCardInfo { get; set; }

        Button MyAccountPageAddCard { get; set; }

        string MyAccountPageConnectionString { get; set; }

        int MyAccountPageAccountTypeID { get; set; }
        int MyAccountPageAccountID { get; set; }
        int MyAccountPageRetailerID { get; set; }
        int MyAccountPageCustomerID { get; set; }

        int MyAccountPageCardNumber{ get; set; }
        int MyAccountPageCardSecurityCode { get; set; }
        decimal MyAccountPageCardBalance{ get; set; }
        bool MyAccountPageIsRefreshing { get; set; }



    }
}
