using CommunityToolkit.Mvvm.Input;
using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class AddTestVM : BaseViewModel
    {
        //This class refers to AddTestWindow.xaml
        public AddTestVM()
        {
            SaveTestCommand = new RelayCommand(SaveTest);
        }

        public Test Test { get; set; } = new Test { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };
        public RoomLetters RoomLetters { get; set; } = new RoomLetters();
        public ICommand SaveTestCommand { get; set; }

        private void SaveTest()
        {
            try
            {
                if (TestDataValidator.ValidateTestData(Test))
                {
                    if (DataSaving.Save(Test))
                    {
                        if (TestsVM.Instance != null)
                        {
                            TestsVM.Instance.Tests = ObjectsDataGetter.GetTestsData();
                            TestsVM.Instance.SortTestsDateAscending();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano kolokwium");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać kolokwium ponownie", "Błąd dodania kolokwium");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }

        public string Name
        {
            get { return Test.Name; }
            set { Test.Name = value; OnPropertyChanged(Name); }
        }

        public DateTime DateOfTest
        {
            get { return Test.DateOfTest; }
            set { Test.DateOfTest = value; OnPropertyChanged(nameof(DateOfTest)); }
        }

        public int? HourOfTest
        {
            get { return Test.HourOfTest; }
            set { Test.HourOfTest = value; OnPropertyChanged(nameof(HourOfTest)); }
        }

        public int? MinuteOfTest
        {
            get { return Test.MinuteOfTest; }
            set { Test.MinuteOfTest = value; OnPropertyChanged(nameof(MinuteOfTest)); }
        }

        public int? RoomNumber
        {
            get { return Test.RoomNumber; }
            set { Test.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }

        public string RoomLetter
        {
            get { return Test.RoomLetter; }
            set { Test.RoomLetter = value; OnPropertyChanged(nameof(RoomLetter)); }
        }

        public List<string> Letters
        {
            get { return RoomLetters.Letters; }
            set { RoomLetters.Letters = value; OnPropertyChanged(nameof(Letters)); }
        }

        public string Note
        {
            get { return Test.Note; }
            set { Test.Note = value; OnPropertyChanged(Note); }
        }
    }
}