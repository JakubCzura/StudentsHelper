﻿using CommunityToolkit.Mvvm.Input;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class StudentsHelperVM : BaseViewModel
    {
        //This class refers to MainWindow.xaml

        public StudentsHelperVM()
        {
            Instance = this;

            Student = ObjectsDataGetter.GetStudentData();
            DegreeCourse = ObjectsDataGetter.GetDegreeCourseData();
            SelectMainWindowContentCommand = new SelectMainWindowContentCommand(this);
            ShowAuthorsWindowCommand = new RelayCommand(ShowAuthorsWindow);
            SelectedMainWindowContent = new WelcomeScreenVM();

            Geckodriver.Geckodriver.CopyGeckodriverToDebugDirectory();
        }

        private void ShowAuthorsWindow()
        {
            AuthorsWindow AuthorsWindow = new();
            AuthorsWindow.Show();
        }
        public static StudentsHelperVM? Instance { get; private set; }

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

        public ICommand SelectMainWindowContentCommand { get; private set; }

        public ICommand ShowAuthorsWindowCommand { get; private set; }

        private BaseViewModel selectedMainWindowContent;

        public BaseViewModel SelectedMainWindowContent
        {
            get { return selectedMainWindowContent; }
            set { selectedMainWindowContent = value; OnPropertyChanged(nameof(SelectedMainWindowContent)); }
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

        public string FullName
        {
            get { return $"{Name} {SecondName}"; }
        }

        public int Age
        {
            get { return Student.Age; }
            set { Student.Age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string Login
        {
            get { return Student.Login; }
            set { Student.Login = value; OnPropertyChanged(nameof(Login)); }
        }

        public string Password
        {
            get { return Student.Password; }
            set { Student.Password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Course
        {
            get { return DegreeCourse.Course; }
            set { DegreeCourse.Course = value; OnPropertyChanged(Course); }
        }

        public int Semester
        {
            get { return DegreeCourse.Semester; }
            set { DegreeCourse.Semester = value; OnPropertyChanged(nameof(Semester)); }
        }
    }
}