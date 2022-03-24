using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
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
                if(LoginWindow.Instance != null)
                {
                    LoginVM.Password = LoginWindow.Instance.PasswordBox.Password;                 
                    if(string.IsNullOrWhiteSpace(LoginVM.Password) || !IsLoginCorrect(LoginVM.Login))
                    {
                        MessageBox.Show("Podaj odpowiednie dane do zalogowania\nPamiętaj, że login zaczyna się od 's'", "Błąd logowania");
                    }
                    else
                    {
                        LoginStudent.Login(LoginVM);
                        MainWindow MainWindow = new MainWindow();
                        LoginStudent.GetStudentData(LoginVM.Instance);
                        MainWindow.Show();
                        LoginWindow.Instance.Close();                                             
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
