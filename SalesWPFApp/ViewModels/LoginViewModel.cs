using DataAccess.Service;
using SalesWPFApp;
using SalesWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModels
{
    public class LoginViewModel
    {
        ILoginManagement loginManagement ;
  
        public LoginViewModel(ILoginManagement loginManagement)
        {
            this.loginManagement = loginManagement;
            string email = null;
            string password = null;
            loginCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                foreach (var para in p)
                {
                    TextBox tb = para as TextBox;
                    PasswordBox pb = para as PasswordBox;
                    if (tb != null&&tb.Name == "Email")
                    {
                        email = tb.Text;
                    }
                    if (pb!=null&& pb.Name == "Password")
                    {
                        password = pb.Password;

                    }

                }
                if (email == null || password == null)
                {
                    LoginFail();
                    return;
                }
                Console.WriteLine("Fail to login");

                if (loginManagement.login(email, password))
                {
                    //switch view references: https://www.youtube.com/watch?v=1_cUgpWqS0Y&ab_channel=SingletonSean
                    Application.Current.Windows[0].Close();

                    LoginSuccess();

                    authorization = loginManagement.authorization();
                    
                }
            });
        }
        public string authorization;
        private void LoginSuccess()
        {
            Application.Current.Windows[0].ShowDialog();
        }
        private void LoginFail()
        {
            //show dialog
        }
        public ICommand loginCommand { get; set; }


    }
}
