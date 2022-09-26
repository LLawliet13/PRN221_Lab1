using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public class LoginViewModel : ViewModelBase 
    {
        public LoginViewModel()
        {
            loginCommand = new RelayCommand<Object>(p => true, p =>
            {
                Console.WriteLine("true");
            });
        }
        public ICommand loginCommand { get; set; }

        
    }
}
