using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;

namespace StudentsHelper.ViewModel
{
    public class EditHomeworkVM : BaseViewModel
    {
        public EditHomeworkVM()
        {
            SelectedHomework = HomeworkVM.Instance.SelectedHomework;
            SaveEditedHomeworkCommand = new SaveEditedHomeworkCommand(this);
            Instance = this;
        }

        public static EditHomeworkVM? Instance { get; set; }

        public SaveEditedHomeworkCommand SaveEditedHomeworkCommand { get; set; }

        public string LessonName
        {
            get { return SelectedHomework.LessonName; }
            set { SelectedHomework.LessonName = value; OnPropertyChanged(LessonName); }
        }

        public DateTime DateOfEnd
        {
            get { return SelectedHomework.DateOfEnd; }
            set { SelectedHomework.DateOfEnd = value; OnPropertyChanged(nameof(DateOfEnd)); }
        }

        public string TeacherName
        {
            get { return SelectedHomework.TeacherName; }
            set { SelectedHomework.TeacherName = value; OnPropertyChanged(TeacherName); }
        }

        public string TeacherSecondName
        {
            get { return SelectedHomework.TeacherSecondName; }
            set { SelectedHomework.TeacherSecondName = value; OnPropertyChanged(TeacherSecondName); }
        }

        public string DateOfEndShort
        {
            get { return SelectedHomework.DateOfEnd.ToShortDateString(); }
        }

        public string Exercise
        {
            get { return SelectedHomework.Exercise; }
            set { SelectedHomework.Exercise = value; OnPropertyChanged(Exercise); }
        }

        public string Note
        {
            get { return SelectedHomework.Note; }
            set { SelectedHomework.Note = value; OnPropertyChanged(Note); }
        }

        private Homework selectedHomework { get; set; }

        public Homework SelectedHomework
        {
            get { return selectedHomework; }
            set { selectedHomework = value; OnPropertyChanged(nameof(SelectedHomework)); }
        }
    }
}