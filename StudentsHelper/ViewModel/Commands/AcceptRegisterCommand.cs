using StudentsHelper.DataBase;
using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class AcceptRegisterCommand : ICommand
    {

        public AcceptRegisterCommand(RegisterWindowVM registerWindowVM)
        {
            RegisterWindowVM = registerWindowVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        RegisterWindowVM RegisterWindowVM { get; set; }

        public bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(RegisterWindowVM.Name) ||
                string.IsNullOrWhiteSpace(RegisterWindowVM.SecondName) ||
                RegisterWindowVM.Age <= 0 || RegisterWindowVM.Age >= 100 ||
                string.IsNullOrWhiteSpace(RegisterWindowVM.Course) ||
                RegisterWindowVM.Semestr <= 0 || RegisterWindowVM.Semestr >= 20 ||
                string.IsNullOrWhiteSpace(RegisterWindowVM.Speciality) ||
                string.IsNullOrWhiteSpace(RegisterWindowVM.Faculty))
            {
                return false;
            }
            return true;
        }

        static bool IsLoginCorrect(string login)
        {
            if (string.IsNullOrWhiteSpace(login) ||
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
                if (RegisterWindow.RegisterWindowInstance != null)
                {
                    RegisterWindowVM.Password = RegisterWindow.RegisterWindowInstance.PasswordBox.Password;
                    //MessageBox.Show(LoginVM.Password);
                    if (string.IsNullOrWhiteSpace(RegisterWindowVM.Password) || !IsLoginCorrect(RegisterWindowVM.Login))
                    {
                        MessageBox.Show("Podaj odpowiednie dane do rejestracji\nPamiętaj, że login zaczyna się od 's'", "Błąd rejestracji");
                    }
                    else
                    {
                        DataBaseHelper.RegisterStudent(RegisterWindowVM);
                        //Tutaj następuje zarejestrowanie użytkownika
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
