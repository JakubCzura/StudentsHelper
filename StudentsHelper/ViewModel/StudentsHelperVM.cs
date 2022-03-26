using StudentsHelper.DataBase;
using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.ViewModel
{
    public class StudentsHelperVM : INotifyPropertyChanged
    {
        //This class refers to MainWindow.xaml
        public static StudentsHelperVM? Instance { get; set; }
        public StudentsHelperVM()
        {
            Instance = this;
            
            DegreeCourse = LoginStudent.GetDegreeCourseData();
            Student = LoginStudent.GetStudentData();
        }

        public Student Student { get; set; }
        
        public DegreeCourse DegreeCourse { get; set; }

        public string Name
        {
            get { return Student.Name; }
            set
            {
                Student.Name = value;
                OnPropertyChanged(Name);
            }
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

        public string FullName
        {
            
            get { return Student.Name + " " + Student.SecondName;  }
        }

        public string Course
        {
            get { return DegreeCourse.Course; }
            set 
            {
                DegreeCourse.Course = value; 
                OnPropertyChanged(Course); 
            }
        }

        public int Semester
        {
            get { return DegreeCourse.Semester; }
            set 
            { 
                DegreeCourse.Semester = value; 
                OnPropertyChanged(nameof(Semester)); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
