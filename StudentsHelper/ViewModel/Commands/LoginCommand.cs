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

        static bool IsLoginCorrect(string login)
        {
            if(string.IsNullOrWhiteSpace(login) ||
                !login.StartsWith('s') ||
                login.Length != 7)
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {          
            try
            {
                if(LoginWindow.LoginWindowInstance != null)
                {
                    LoginVM.Password = LoginWindow.LoginWindowInstance.PasswordBox.Password;                 
                    if(string.IsNullOrWhiteSpace(LoginVM.Password) || !IsLoginCorrect(LoginVM.Login))
                    {
                        MessageBox.Show("Podaj odpowiednie dane do zalogowania\nPamiętaj, że login zaczyna się od 's'", "Błąd logowania");
                    }
                    else
                    {
                        MainWindow MainWindow = new MainWindow();
                        MainWindow.Show();
                        LoginWindow.LoginWindowInstance.Close();
                    }                  
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);               
            }                       
        }
    }
}
