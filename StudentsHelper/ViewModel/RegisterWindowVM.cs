using CommunityToolkit.Mvvm.Input;
using OpenQA.Selenium.DevTools.V104.Network;
using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Windows;
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
            RegisterCommand = new RelayCommand(Register);
            BackToLoginCommand = new RelayCommand(BackToLogin);
            StudentRegistration = new();
        }

        private void Register()
        {
            try
            {
                if (RegisterWindow.Instance != null)
                {
                    Password = RegisterWindow.Instance.PasswordBox.Password;
                    if (StudentDataValidator.ValidatePassword(Password) && StudentDataValidator.ValidateLogin(Login))
                    {
                        if (StudentDataValidator.ValidateStudentData(Student))
                        {
                            Password = Hasher.HashPassword(Password);
                            DegreeCourse.StudentId = Student.Id;
                            if (StudentRegistration.Register(Student, DegreeCourse) == true)
                            {
                                LoginWindow LoginWindow = new();
                                LoginWindow.Show();
                                RegisterWindow.Instance.Close();
                                MessageBox.Show("Rejestracja przebiegła pomyślnie\nMożesz się zalogować!", "Zarejestrowano");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BackToLogin()
        {
            LoginWindow LoginWindow = new();
            LoginWindow.Show();
            RegisterWindow.Instance?.Close();
        }

        private Student student;

        public Student Student 
        { 
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        private DegreeCourse degreeCourse;

        public DegreeCourse DegreeCourse 
        { 
            get { return degreeCourse; }
            set { degreeCourse = value; OnPropertyChanged(nameof(DegreeCourse)); } 
        }
        public ICommand RegisterCommand { get; private set; }

        private StudentRegistration StudentRegistration { get; set; }

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