using CommunityToolkit.Mvvm.Input;
using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.View.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class LoginVM : BaseViewModel
    {
        //This class refers to LoginWindow.xaml

        public LoginVM()
        {
            Instance = this;
            LoginCommand = new RelayCommand(LogIn);
            ShowRegisterWindowCommand = new RelayCommand(ShowRegisterWindow);
            DataBaseHelper.CreateEmptyDataBase();
        }

        private void LogIn()
        {
            try
            {
                ObjectsDataGetter loginStudent = new();
                if (LoginWindow.Instance != null)
                {
                    Password = LoginWindow.Instance.PasswordBox.Password;
                    if (!StudentDataValidator.ValidateLogin(Login) || !StudentDataValidator.ValidatePassword(Password))
                    {
                        MessageBox.Show("Podaj odpowiednie dane do zalogowania\nPamiętaj, że login zaczyna się od 's'", "Błąd logowania");
                    }
                    else
                    {
                        if (LoggingInManager.LogIn(Password, Login) == true)
                        {
                            MainWindow MainWindow = new();
                            MainWindow.Show();
                            LoginWindow.Instance.Close();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public LoginVM Instance { get; private set; }

        public ICommand LoginCommand { get; private set; }

        public ICommand ShowRegisterWindowCommand { get; private set; }

        private void ShowRegisterWindow()
        {
            RegisterWindow RegisterWindow = new();
            RegisterWindow.Show();
            LoginWindow.Instance?.Close();
        }

        private int id = 0;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(Name); }
        }

        private string secondName = string.Empty;

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; OnPropertyChanged(SecondName); }
        }

        private int age = 0;

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        private string login = string.Empty;

        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(nameof(Login)); }
        }

        private string password = string.Empty;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }
    }
}