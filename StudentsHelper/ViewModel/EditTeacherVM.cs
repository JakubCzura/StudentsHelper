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
    public class EditTeacherVM : BaseViewModel
    {
        public EditTeacherVM()
        {
            SelectedTeacher = TeachersVM.Instance.SelectedTeacher;
            SaveEditedTeacherCommand = new SaveEditedTeacherCommand(this);
            Instance = this;
        }

        public static EditTeacherVM? Instance { get; set; }

        public SaveEditedTeacherCommand SaveEditedTeacherCommand { get; set; }            

        public string Lesson
        {
            get { return SelectedTeacher.Lesson; }
            set { SelectedTeacher.Lesson = value; OnPropertyChanged(Lesson); }
        }

        public string Name
        {
            get { return SelectedTeacher.Name; }
            set { SelectedTeacher.Name = value; OnPropertyChanged(Name); }
        }

        public string Degree
        {
            get { return SelectedTeacher.Degree; }
            set { SelectedTeacher.Degree = value; OnPropertyChanged(Degree); }
        }

        public int RoomNumber
        {
            get { return SelectedTeacher.RoomNumber; }
            set { SelectedTeacher.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }


        public string LastName
        {
            get { return SelectedTeacher.LastName; }
            set { SelectedTeacher.LastName = value; OnPropertyChanged(LastName); }
        }

        public string Note
        {
            get { return SelectedTeacher.Note; }
            set { SelectedTeacher.Note = value; OnPropertyChanged(Note); }
        }

        private Teacher selectedTeacher { get; set; }
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set { selectedTeacher = value; OnPropertyChanged(nameof(SelectedTeacher)); }
        }
    }
}
