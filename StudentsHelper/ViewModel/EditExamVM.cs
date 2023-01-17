using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class EditExamVM : BaseViewModel
    {
        public EditExamVM()
        {
            SelectedExam = ExamsVM.Instance.SelectedExam;
            SaveEditedExamCommand = new SaveEditedExamCommand(this);
            RoomLetters = new();
            Instance = this;
        }

        public static EditExamVM? Instance { get; set; }

        public RoomLetters RoomLetters { get; set; }

        public ICommand SaveEditedExamCommand { get; private set; }

        public string Name
        {
            get { return SelectedExam.Name; }
            set { SelectedExam.Name = value; OnPropertyChanged(Name); }
        }

        public DateTime DateOfExam
        {
            get { return SelectedExam.DateOfExam; }
            set { SelectedExam.DateOfExam = value; OnPropertyChanged(nameof(DateOfExam)); }
        }

        public int? HourOfExam
        {
            get { return SelectedExam.HourOfExam; }
            set { SelectedExam.HourOfExam = value; OnPropertyChanged(nameof(HourOfExam)); }
        }

        public int? MinuteOfExam
        {
            get { return SelectedExam.MinuteOfExam; }
            set { SelectedExam.MinuteOfExam = value; OnPropertyChanged(nameof(MinuteOfExam)); }
        }

        public int? RoomNumber
        {
            get { return SelectedExam.RoomNumber; }
            set { SelectedExam.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }

        public string RoomLetter
        {
            get { return SelectedExam.RoomLetter; }
            set { SelectedExam.RoomLetter = value; OnPropertyChanged(nameof(RoomLetter)); }
        }

        public List<string> Letters
        {
            get { return RoomLetters.Letters; }
            set { RoomLetters.Letters = value; OnPropertyChanged(nameof(Letters)); }
        }

        public string Note
        {
            get { return SelectedExam.Note; }
            set { SelectedExam.Note = value; OnPropertyChanged(Note); }
        }

        private Exam selectedExam { get; set; }

        public Exam SelectedExam
        {
            get { return selectedExam; }
            set { selectedExam = value; OnPropertyChanged(nameof(SelectedExam)); }
        }
    }
}