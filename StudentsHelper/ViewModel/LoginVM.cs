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

        public LoginVM()
        {
            LoginCommand = new LoginCommand(this);
        }
        
        public LoginCommand LoginCommand { get; set; }

        Student Student = new Student();
        public string Login
        {
            get { return Student.Login; }
            set
            {
                Student.Login = value;
                OnPropertyChanged(Login);
            }
        }

      

        public string Password
        {
            get { return Student.Password; }
            set 
            { 
                Student.Password = value; 
                OnPropertyChanged(Password); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
