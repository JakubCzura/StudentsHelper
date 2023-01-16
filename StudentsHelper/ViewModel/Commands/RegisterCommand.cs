using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.View.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public RegisterCommand(RegisterWindowVM registerWindowVM)
        {
            RegisterWindowVM = registerWindowVM;
        }

        private RegisterWindowVM RegisterWindowVM { get; set; }

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
                RegisterStudent registerStudent = new();
                if (RegisterWindow.Instance != null)
                {
                    RegisterWindowVM.Password = RegisterWindow.Instance.PasswordBox.Password;

                    if (StudentDataValidator.ValidatePassword(RegisterWindowVM.Password) &&
                        StudentDataValidator.ValidateLogin(RegisterWindowVM.Login))
                    {
                        RegisterWindowVM.Password = Hasher.HashPassword(RegisterWindowVM.Password);
                        StudentDataValidator.ValidateStudentData(RegisterWindowVM.Student);
                        if (registerStudent.Register(RegisterWindowVM) == true)
                        {
                            LoginWindow LoginWindow = new LoginWindow();
                            LoginWindow.Show();
                            RegisterWindow.Instance.Close();
                            MessageBox.Show("Rejestracja przebiegła pomyślnie\nMożesz się zalogować!", "Zarejestrowano");
                        }
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