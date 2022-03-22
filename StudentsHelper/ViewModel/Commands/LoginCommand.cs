using StudentsHelper.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginCommand(LoginVM loginVM)
        {
            LoginVM = loginVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        LoginVM LoginVM { get; set; }

        public bool CanExecute(object? parameter)
        {         
            return true;
        }

        public void Execute(object? parameter)
        {          
            try
            {
                LoginWindow LoginWindow = new LoginWindow();
                string name = LoginWindow.PasswordBox.Password;
                LoginVM.Password = name;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);               
            }  
            
            
        }
    }
}
