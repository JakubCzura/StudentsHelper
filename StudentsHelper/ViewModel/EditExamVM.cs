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
    public class EditExamVM
    {
        public static new EditExamVM? Instance { get; set; }

        public SaveEditedExamCommand SaveEditedExamCommand { get; set; }
        public EditExamVM()
        {
            SelectedExam = ExamsVM.Instance.SelectedExam;
            SaveEditedExamCommand = new SaveEditedExamCommand(this);
            Instance = this;
        }

        public string Name
        {
            get { return SelectedExam.Name; }
            set { SelectedExam.Name = value; OnPropertyChanged(Name); }
        }

        public DateTime DateOfExam
        {
            get { return SelectedExam.DateOfExam; }
            set
            {
                SelectedExam.DateOfExam = value;
                OnPropertyChanged(nameof(DateOfExam));
            }
        }

        public int? HourOfExam
        {
            get { return SelectedExam.HourOfExam; }
            set
            {
                SelectedExam.HourOfExam = value;
                OnPropertyChanged(nameof(HourOfExam));
            }
        }

        public int? MinuteOfExam
        {
            get { return SelectedExam.MinuteOfExam; }
            set
            {
                SelectedExam.MinuteOfExam = value;
                OnPropertyChanged(nameof(MinuteOfExam));
            }
        }
        public int? RoomNumber
        {
            get { return SelectedExam.RoomNumber; }
            set
            {
                SelectedExam.RoomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public string Note
        {
            get { return SelectedExam.Note; }
            set
            {
                SelectedExam.Note = value;
                OnPropertyChanged(Note);
            }
        }

        private Exam selectedExam { get; set; }
        public Exam SelectedExam
        {
            get
            {
                return selectedExam;
            }
            set
            {
                selectedExam = value;
                OnPropertyChanged(nameof(SelectedExam));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
