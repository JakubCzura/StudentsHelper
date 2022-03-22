using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class StudentsHelperVM : INotifyPropertyChanged
    {

        public StudentsHelperVM()
        {

        }

        Student Student = new Student { Name = "Mac", SecondName = "Donald"};
        DegreeCourse DegreeCourse = new DegreeCourse { Semester = 1, Course = "Informatyka"};

        public string Name
        {
            get { return Student.Name; }
            set
            {
                Student.Name = value;
                OnPropertyChanged(Name);
            }
        }

        public string FullName
        {
            get { return Student.Name + " " + Student.SecondName; }
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
