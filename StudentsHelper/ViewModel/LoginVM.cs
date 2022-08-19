using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentsHelper.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        //This class refers to LoginWindow.xaml
       
        public LoginVM()
        {
            Instance = this;
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand();
            DataBaseHelper.CreateEmptyDataBase();
        }
        public LoginVM Instance { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public RegisterCommand RegisterCommand { get; set; }

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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
