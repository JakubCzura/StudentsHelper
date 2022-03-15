using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    internal class AddExamVM : INotifyPropertyChanged
    {
        public AddExamVM()
        {
            CloseWindowCommand = new CloseWindowCommand(this);

        }

        public CloseWindowCommand CloseWindowCommand { get; set; }

        public AddExamWindow AddExamWindow { get; set; }

        public Exam Exam = new Exam();

        public string Name
        {
            get { return Exam.Name; }
            set
            {
                Exam.Name = value;
                OnPropertyChanged(Name);
            }
        }

        public DateTime DateOfExam
        {
            get { return Exam.DateOfExam; }
            set
            {
                Exam.DateOfExam = value;
                OnPropertyChanged(nameof(DateOfExam));
            }
        }

        public DateTime HourOfExam
        {
            get { return Exam.HourOfExam; }
            set
            {
                Exam.HourOfExam = value;
                OnPropertyChanged(nameof(HourOfExam));
            }
        }
        public int RoomNumber
        {
            get { return Exam.RoomNumber; }
            set
            {
                Exam.RoomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public string Note
        {
            get { return Exam.Note; }
            set
            {
                Exam.Note = value;
                OnPropertyChanged(Note);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
