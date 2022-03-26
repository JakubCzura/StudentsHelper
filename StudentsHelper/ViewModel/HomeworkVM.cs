using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class HomeworkVM : INotifyPropertyChanged
    {
        //This class refers to HomeworkUserControl.xaml

        public static HomeworkVM? Instance { get; set; }

        private ObservableCollection<Homework> homework = LoginStudent.GetHomeworkData();

        public HomeworkVM()
        {

            Instance = this;
        }

        public ObservableCollection<Homework> Homework
        {
            get { return homework; }
            set
            {
                homework = value;
                OnPropertyChanged(nameof(Homework));
            }
        }



        //[PrimaryKey, AutoIncrement]
        //public int Id
        //{
        //    get { return Homework.Id; }
        //    set { Homework.Id = value; OnPropertyChanged(nameof(Id)); }
        //}

        //public string LessonName
        //{
        //    get { return Homework.LessonName; }
        //    set { Homework.LessonName = value; OnPropertyChanged(LessonName); }
        //}

        //public string TeacherName
        //{
        //    get { return Homework.TeacherName; }
        //    set { Homework.TeacherName = value; OnPropertyChanged(TeacherName); }
        //}

        //public string TeacherSecondName
        //{
        //    get { return Homework.TeacherSecondName; }
        //    set { Homework.TeacherSecondName = value; OnPropertyChanged(TeacherSecondName); }
        //}

        //public string TeacherFullName
        //{
        //    get { return $"{Homework.TeacherName} {Homework.TeacherSecondName}"; }
        //}
        //public DateTime DateOfEnd
        //{
        //    get { return Homework.DateOfEnd; }
        //    set { Homework.DateOfEnd = value; OnPropertyChanged(nameof(DateOfEnd)); }
        //}

        //public string DateOfEndShort
        //{
        //    get { return Homework.DateOfEnd.ToShortDateString(); }
        //}

        //public string Note
        //{
        //    get { return Homework.Note; }
        //    set { Homework.Note = value; OnPropertyChanged(nameof(Note)); }
        //}

        //public string Exercise
        //{
        //    get { return Homework.Exercise; }
        //    set { Homework.Exercise = value; OnPropertyChanged(Exercise); }
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
