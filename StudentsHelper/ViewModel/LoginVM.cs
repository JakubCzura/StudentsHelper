using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.ViewModel.Commands;

namespace StudentsHelper.ViewModel
{
    public class LoginVM : BaseViewModel
    {
        //This class refers to LoginWindow.xaml

        public LoginVM()
        {
            Instance = this;
            LoginCommand = new LoginCommand(this);
            ShowRegisterWindowCommand = new ShowRegisterWindowCommand();
            DataBaseHelper.CreateEmptyDataBase();
        }

        public LoginVM Instance { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public ShowRegisterWindowCommand ShowRegisterWindowCommand { get; set; }

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