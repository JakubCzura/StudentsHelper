using StudentsHelper.DataBase;
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
    public class AddTeacherVM : INotifyPropertyChanged
    {
        //This class refers to AddHomeworkWindow.xaml
        public Teacher Teacher { get; set; } = new Teacher { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public SaveTeacherCommand SaveTeacherCommand { get; set; }

        public AddTeacherVM()
        {
            SaveTeacherCommand = new SaveTeacherCommand(this);
        }

        public string Lesson
        {
            get { return Teacher.Lesson; }
            set
            {
                Teacher.Lesson = value;
                OnPropertyChanged(Lesson);
            }
        }

        public string Name
        {
            get { return Teacher.Name; }
            set { Teacher.Name = value; OnPropertyChanged(Name); }
        }

        public string Degree
        {
            get { return Teacher.Degree; }
            set { Teacher.Degree = value; OnPropertyChanged(Degree); }
        }

        public int RoomNumber
        {
            get { return Teacher.RoomNumber; }
            set { Teacher.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }


        public string LastName
        {
            get { return Teacher.LastName; }
            set { Teacher.LastName = value; OnPropertyChanged(LastName); }
        }

        public string Note
        {
            get { return Teacher.Note; }
            set { Teacher.Note = value; OnPropertyChanged(Note); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
