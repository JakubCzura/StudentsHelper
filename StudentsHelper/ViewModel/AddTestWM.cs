using StudentsHelper.DataBase;
using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class AddTestWM : INotifyPropertyChanged
    {
        public Exam Test { get; set; } = new Exam { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public SaveTestCommand SaveTestCommand { get; set; }

        public AddTestWM()
        {
            SaveTestCommand = new SaveTestCommand(this);
        }

        public string Name
        {
            get { return Test.Name; }
            set
            {
                Test.Name = value;
                OnPropertyChanged(Name);
            }
        }

        public DateTime DateOfExam
        {
            get { return Test.DateOfExam; }
            set
            {
                Test.DateOfExam = value;
                OnPropertyChanged(nameof(DateOfExam));
            }
        }

        public int? HourOfExam
        {
            get { return Test.HourOfExam; }
            set
            {
                Test.HourOfExam = value;
                OnPropertyChanged(nameof(HourOfExam));
            }
        }

        public int? MinuteOfExam
        {
            get { return Test.MinuteOfExam; }
            set
            {
                Test.MinuteOfExam = value;
                OnPropertyChanged(nameof(MinuteOfExam));
            }
        }
        public int? RoomNumber
        {
            get { return Test.RoomNumber; }
            set
            {
                Test.RoomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public string Note
        {
            get { return Test.Note; }
            set
            {
                Test.Note = value;
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
