using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;

namespace StudentsHelper.ViewModel
{
    public class AddHomeworkVM : BaseViewModel
    {
        //This class refers to AddHomeworkWindow.xaml
        public AddHomeworkVM()
        {
            SaveHomeworkCommand = new SaveHomeworkCommand(this);
        }

        public Homework Homework { get; set; } = new Homework { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public SaveHomeworkCommand SaveHomeworkCommand { get; set; }

        public string LessonName
        {
            get { return Homework.LessonName; }
            set { Homework.LessonName = value; OnPropertyChanged(LessonName); }
        }

        public DateTime DateOfEnd
        {
            get { return Homework.DateOfEnd; }
            set { Homework.DateOfEnd = value; OnPropertyChanged(nameof(DateOfEnd)); }
        }

        public string TeacherName
        {
            get { return Homework.TeacherName; }
            set { Homework.TeacherName = value; OnPropertyChanged(TeacherName); }
        }

        public string TeacherSecondName
        {
            get { return Homework.TeacherSecondName; }
            set { Homework.TeacherSecondName = value; OnPropertyChanged(TeacherSecondName); }
        }

        public string Exercise
        {
            get { return Homework.Exercise; }
            set { Homework.Exercise = value; OnPropertyChanged(Exercise); }
        }

        public string Note
        {
            get { return Homework.Note; }
            set { Homework.Note = value; OnPropertyChanged(Note); }
        }
    }
}