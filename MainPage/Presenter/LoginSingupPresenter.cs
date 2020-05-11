using MainPage.Interface;
using MainPage.Model;
using MainPage.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Presenter
{
    class LoginSingupPresenter
    {
        LoginSignUpInterface LoginSignupView;
        LoginSignupModel model = new LoginSignupModel();
        LoginSignUpObject obj = new LoginSignUpObject();
        DataTable Dt;
    
        public LoginSingupPresenter( LoginSignUpInterface ILoginSignupView)
        {
            LoginSignupView = ILoginSignupView;

        }

        public void LoadAccountTypes()
        {
            LoginSignupView.AccountType.DataSource = model.LoadAccountTypes();
            LoginSignupView.AccountType.DisplayMember = "Description";
            LoginSignupView.AccountType.ValueMember = "AccountTypeID";
            LoginSignupView.AccountType.SelectedIndex = 0;

        }

        public Boolean SignUp()
        {
            
            LoginSignUpObject obj = new LoginSignUpObject();
            obj.SignUpUsername = LoginSignupView.SignUpUsernameTxtB.Text;
            obj.SignUpPassword = LoginSignupView.SignUpPasswordTxtB.Text;
            obj.SignupFirstName = LoginSignupView.SignupFirstNameTxtB.Text;
            obj.SingupLastName = LoginSignupView.SingupLastNameTxtB.Text;
            obj.SingupDateOfBirth = LoginSignupView.SingupDateOfBirth.Value;
            obj.AccountTypeID = int.Parse(LoginSignupView.AccountType.SelectedValue.ToString()) ;

            int i = DateTime.Now.Year - LoginSignupView.SingupDateOfBirth.Value.Year;
            if (i >= 18)
            {
                return model.SignUp(obj);
            }
            else
            {
                MessageBox.Show("You Must be 18+ to Register");

                return false;
            }
            
        
        }

        public Boolean Login()
          {
            bool found = false;
        

        
            obj.LoginUsername = LoginSignupView.LoginUsernameTxtB.Text;
            obj.LoginPassword = LoginSignupView.LoginPasswordTxtB.Text;
            Dt =model.Login(obj, LoginSignupView.LoginSingupConnectionString);
            foreach (DataRow Dr in Dt.Rows)
            {
                if (Dr["Username"].ToString() == obj.LoginUsername && Dr["Password"].ToString() == obj.LoginPassword)
                {
                    LoginSignupView.LoginSingupAccountID = int.Parse( Dr["AccountID"].ToString());
                    LoginSignupView.LoginSingupAccountTypeID = int.Parse(Dr["AccountTypeID"].ToString());
                    int i = int.Parse(Dr["AccountTypeID"].ToString()); ;
                    if (LoginSignupView.LoginSingupAccountTypeID == 0)
                    {
               
                        LoginSignupView.LoginSingupCustomerID = Int32.Parse(Dr["CustomerID"].ToString());

                    }
                    else
                    {
                        LoginSignupView.LoginSingupRetailerID = Int32.Parse(Dr["RetailerID"].ToString());
                    }
                    found = true;
                }
            }

 


            return found;
        }
    }
}
