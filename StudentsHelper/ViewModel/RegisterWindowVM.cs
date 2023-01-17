using CommunityToolkit.Mvvm.Input;
using OpenQA.Selenium.DevTools.V104.Network;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class RegisterWindowVM : BaseViewModel
    {
        //This class refers to RegisterWindow.xaml
        public RegisterWindowVM()
        {
            Student = new Student();
            DegreeCourse = new DegreeCourse();
            RegisterCommand = new RegisterCommand(this);
            BackToLoginCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(BackToLogin);
        }

        private void BackToLogin()
        {
            LoginWindow LoginWindow = new();
            LoginWindow.Show();
            RegisterWindow.Instance?.Close();
        }

        public Student Student { get; set; }
        public DegreeCourse DegreeCourse { get; set; }
        public RegisterCommand RegisterCommand { get; private set; }

        public ICommand BackToLoginCommand { get; private set; }

        public int Id
        {
            get { return Student.Id; }
            set { Student.Id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get { return Student.Name; }
            set { Student.Name = value; OnPropertyChanged(Name); }
        }

        public string SecondName
        {
            get { return Student.SecondName; }
            set { Student.SecondName = value; OnPropertyChanged(SecondName); }
        }

        public int Age
        {
            get { return Student.Age; }
            set { Student.Age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string Course
        {
            get { return DegreeCourse.Course; }
            set { DegreeCourse.Course = value; OnPropertyChanged(Course); }
        }

        public int Semestr
        {
            get { return DegreeCourse.Semester; }
            set { DegreeCourse.Semester = value; OnPropertyChanged(nameof(Semestr)); }
        }

        public string Speciality
        {
            get { return DegreeCourse.Speciality; }
            set { DegreeCourse.Speciality = value; OnPropertyChanged(Speciality); }
        }

        public string Faculty
        {
            get { return DegreeCourse.Faculty; }
            set { DegreeCourse.Faculty = value; OnPropertyChanged(Faculty); }
        }

        public string Email
        {
            get { return Student.Email; }
            set { Student.Email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Login
        {
            get { return Student.Login; }
            set { Student.Login = value; OnPropertyChanged(Login); }
        }

        public string Password
        {
            get { return Student.Password; }
            set { Student.Password = value; OnPropertyChanged(Password); }
        }
    }
}