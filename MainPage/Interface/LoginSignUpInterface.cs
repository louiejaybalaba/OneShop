using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface LoginSignUpInterface
    {
         TextBox LoginUsernameTxtB { get; set; }
         TextBox LoginPasswordTxtB { get; set; }
         Button  LoginBtn          { get; set; }
         Button LoginSetUpConnection { get; set; }

         TextBox SignUpUsernameTxtB { get; set; }
         TextBox SignUpPasswordTxtB { get; set; }
         TextBox SignupFirstNameTxtB { get; set; }
         TextBox SingupLastNameTxtB { get; set; }
         DateTimePicker SingupDateOfBirth { get; set; }
         ComboBox AccountType { get; set; }
         Button SignUpSubmit { get; set; }

        int LoginSingupAccountID { get; set; }
        int LoginSingupCustomerID { get; set; }
        int LoginSingupRetailerID { get; set; }
        int LoginSingupAccountTypeID { get; set; }

        //decimal LoginSingupRetailerProfits { get; set; }
        String LoginSingupConnectionString { get; set; }

}
}
