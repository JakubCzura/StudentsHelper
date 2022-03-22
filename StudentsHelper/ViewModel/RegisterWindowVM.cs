using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class RegisterWindowVM : INotifyPropertyChanged
    {
        public RegisterWindowVM()
        {
            Student = new Student();
            DegreeCourse = new DegreeCourse();
            AcceptRegisterCommand = new AcceptRegisterCommand();
        }

        Student Student { get; set; }
        DegreeCourse DegreeCourse { get; set; }
        public AcceptRegisterCommand AcceptRegisterCommand { get; set; }

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
            set { DegreeCourse.Speciality = value; OnPropertyChanged((Speciality)); }
        }

        public string Faculty
        {
            get { return DegreeCourse.Faculty; }
            set { DegreeCourse.Faculty = value; OnPropertyChanged((Faculty)); }
        }

        public string Login
        {
            get { return Student.Login; }
            set { Student.Login = value; OnPropertyChanged((Login)); }
        }

        public string Password
        {
            get { return Student.Password; }
            set { Student.Password = value; OnPropertyChanged((Password)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
