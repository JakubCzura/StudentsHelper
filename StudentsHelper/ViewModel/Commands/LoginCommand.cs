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
            try
            {
                PasswordBox PasswordBox = parameter as PasswordBox;
                if (PasswordBox != null)
                {
                    if (string.IsNullOrWhiteSpace(PasswordBox.Password) || string.IsNullOrEmpty(PasswordBox.Password) || !PasswordBox.Password.StartsWith('s'))
                    {
                        return false;
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
          
            return true;
        }

        public void Execute(object? parameter)
        {
            PasswordBox passwordBox = (PasswordBox)parameter;


            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            
        }
    }
}
