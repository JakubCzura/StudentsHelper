using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
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
        
        public StudentsHelperVM()
        {
            Instance = this;

            DegreeCourse = LoginStudent.GetDegreeCourseData();
            Student = LoginStudent.GetStudentData();
            SetExamsVisibleCommand = new SetExamsVisibleCommand();
            SetHomeworkVisibleCommand = new SetHomeworkVisibleCommand();
            SetTestsVisibleCommand = new SetTestsVisibleCommand();
            SetTeachersVisibleCommand = new SetTeachersVisibleCommand();
            SetNotesVisibleCommand = new SetNotesVisibleCommand();
            SetUserProfileVisibleCommand = new SetUserProfileVisibleCommand();
            SetSettingsVisibleCommand = new SetSettingsVisibleCommand();
            SetWelcomeScreenVisibleCommand = new SetWelcomeScreenVisibleCommand();
        }

        public static StudentsHelperVM? Instance { get; set; }
        
        public Student Student { get; set; }

        public DegreeCourse DegreeCourse { get; set; }

        public SetExamsVisibleCommand SetExamsVisibleCommand { get; set; }

        public SetHomeworkVisibleCommand SetHomeworkVisibleCommand { get; set; }

        public SetTestsVisibleCommand SetTestsVisibleCommand { get; set; }

        public SetTeachersVisibleCommand SetTeachersVisibleCommand { get; set; }

        public SetNotesVisibleCommand SetNotesVisibleCommand{ get; set; }

        public SetUserProfileVisibleCommand SetUserProfileVisibleCommand{ get; set; }

        public SetSettingsVisibleCommand SetSettingsVisibleCommand{ get; set; }

        public SetWelcomeScreenVisibleCommand SetWelcomeScreenVisibleCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        
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
       
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
