using CommunityToolkit.Mvvm.Input;
using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class AddExamVM : BaseViewModel
    {
        //This class refers to AddExamWindow.xaml
        public AddExamVM()
        {
            SaveExamCommand = new RelayCommand(SaveExam);
        }

        private void SaveExam()
        {
            try
            {
                if (ExamDataValidator.ValidateExamData(Exam))
                {
                    if (DataSaving.Save(Exam))
                    {
                        if (ExamsVM.Instance != null)
                        {
                            ExamsVM.Instance.Exams = ObjectsDataGetter.GetExamsData();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano egzamin");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać egzamin ponownie", "Błąd dodania egzaminu");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }

        public Exam Exam { get; set; } = new Exam { StudentId = DataBaseHelper.StudentId };

        public RoomLetters RoomLetters { get; set; } = new RoomLetters();
        public ICommand SaveExamCommand { get; set; }

        public string Name
        {
            get { return Exam.Name; }
            set { Exam.Name = value; OnPropertyChanged(Name); }
        }

        public DateTime DateOfExam
        {
            get { return Exam.DateOfExam; }
            set {  Exam.DateOfExam = value; OnPropertyChanged(nameof(DateOfExam)); }
        }

        public int? HourOfExam
        {
            get { return Exam.HourOfExam; }
            set {Exam.HourOfExam = value; OnPropertyChanged(nameof(HourOfExam)); }
        }

        public int? MinuteOfExam
        {
            get { return Exam.MinuteOfExam; }
            set { Exam.MinuteOfExam = value; OnPropertyChanged(nameof(MinuteOfExam)); }
        }

        public int? RoomNumber
        {
            get { return Exam.RoomNumber; }
            set { Exam.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }

        public string RoomLetter
        {
            get { return Exam.RoomLetter; }
            set { Exam.RoomLetter = value; OnPropertyChanged(nameof(RoomLetter)); }
        }

        public List<string> Letters
        {
            get { return RoomLetters.Letters; }
            set { RoomLetters.Letters = value; OnPropertyChanged(nameof(Letters)); }
        }

        public string Note
        {
            get { return Exam.Note; }
            set { Exam.Note = value; OnPropertyChanged(Note); }
        }
    }
}