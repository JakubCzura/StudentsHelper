using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    public class Homework : INotifyPropertyChanged
    {
        private int id { get; set; } = 0;

        public int Id 
        { 
            get { return id; } 
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        private string lessonName = string.Empty;
        public string LessonName
        {
            get { return lessonName; }
            set { lessonName = value; OnPropertyChanged(LessonName); }
        }

        private string studentName = string.Empty;

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; OnPropertyChanged(StudentName); }
        }

        private string studentSecondName = string.Empty;

        public string StudentSecondName
        {
            get { return studentSecondName; }
            set { studentSecondName = value; OnPropertyChanged(StudentSecondName); }
        }

        private string teacherName = string.Empty;

        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; OnPropertyChanged(TeacherName); }
        }

        private string teacherSecondName = string.Empty;

        public string TeacherSecondName
        {
            get { return teacherSecondName; }
            set { teacherSecondName = value; OnPropertyChanged(TeacherSecondName); }
        }

        private DateTime dateOfBeginning;

        public DateTime DateOfBeginning
        {
            get { return dateOfBeginning; }
            set { dateOfBeginning = value; OnPropertyChanged(nameof(DateOfBeginning)); }
        }

        public string DateOfBeginningShort
        {
            get { return DateOfBeginning.ToShortDateString(); }
        }

        private DateTime dateOfEnd;
        public DateTime DateOfEnd
        {
            get { return dateOfEnd; }
            set { dateOfEnd = value; OnPropertyChanged(nameof(DateOfEnd)); }
        }

        public string DateOfEndShort
        {
            get { return DateOfEnd.ToShortDateString(); }
        }




        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
