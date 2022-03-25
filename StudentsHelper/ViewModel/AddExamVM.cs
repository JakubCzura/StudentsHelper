using StudentsHelper.DataBase;
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
    public class AddExamVM : INotifyPropertyChanged
    {

        public Exam Exam { get; set; } = new Exam("Matma", new DateTime(2022, 12, 1), 21, "Super", 12, 30, 20)
        { StudentLogin = DataBaseHelper.StudentLogin };

        public SaveExamsCommand SaveExamsCommand { get; set; }

        public AddExamVM()
        {
            SaveExamsCommand = new SaveExamsCommand(this);
        }

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

        public int HourOfExam
        {
            get { return Exam.HourOfExam; }
            set
            {
                Exam.HourOfExam = value;
                OnPropertyChanged(nameof(HourOfExam));
            }
        }

        public int MinuteOfExam
        {
            get { return Exam.MinuteOfExam; }
            set
            {
                Exam.MinuteOfExam = value;
                OnPropertyChanged(nameof(MinuteOfExam));
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
