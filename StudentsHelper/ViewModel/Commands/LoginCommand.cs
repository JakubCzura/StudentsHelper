using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.View.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginCommand(LoginVM loginVM)
        {
            LoginVM = loginVM;
        }

        private LoginVM LoginVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                StudentLoggingIn loginStudent = new();
                if (LoginWindow.Instance != null)
                {
                    LoginVM.Password = LoginWindow.Instance.PasswordBox.Password;
                    if (!StudentDataValidator.ValidateLogin(LoginVM.Login) || !StudentDataValidator.ValidatePassword(LoginVM.Password))
                    {
                        MessageBox.Show("Podaj odpowiednie dane do zalogowania\nPamiętaj, że login zaczyna się od 's'", "Błąd logowania");
                    }
                    else
                    {
                        //if (loginStudent.LogIn(LoginVM) == true)
                        //{
                        //    MainWindow MainWindow = new();
                        //    MainWindow.Show();
                        //    LoginWindow.Instance.Close();
                        //}
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