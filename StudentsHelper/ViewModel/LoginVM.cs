using CommunityToolkit.Mvvm.Input;
using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
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
            LoginCommand = new LoginCommand(this);
            ShowRegisterWindowCommand = new RelayCommand(ShowRegisterWindow);
            DataBaseHelper.CreateEmptyDataBase();
        }
  
        public LoginVM Instance { get; private set; }

        public LoginCommand LoginCommand { get; private set; }

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