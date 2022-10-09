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
    public class AddExamVM : BaseViewModel
    {
        //This class refers to AddExamWindow.xaml
        public AddExamVM()
        {
            SaveExamCommand = new SaveExamCommand(this);
        }

        public Exam Exam { get; set; } = new Exam { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public RoomLetters RoomLetters { get; set; } = new RoomLetters();
        public SaveExamCommand SaveExamCommand { get; set; }        

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

        public int? HourOfExam
        {
            get { return Exam.HourOfExam; }
            set
            {
                Exam.HourOfExam = value;
                OnPropertyChanged(nameof(HourOfExam));
            }
        }

        public int? MinuteOfExam
        {
            get { return Exam.MinuteOfExam; }
            set
            {
                Exam.MinuteOfExam = value;
                OnPropertyChanged(nameof(MinuteOfExam));
            }
        }
        public int? RoomNumber
        {
            get { return Exam.RoomNumber; }
            set
            {
                Exam.RoomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        public string RoomLetter
        {
            get { return Exam.RoomLetter; }
            set
            {
                Exam.RoomLetter = value;
                OnPropertyChanged(nameof(RoomLetter));
            }
        }

        public List<string> Letters
        {
            get { return RoomLetters.Letters; }
            set
            {
                RoomLetters.Letters = value;
                OnPropertyChanged(nameof(Letters));
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
    }
}
