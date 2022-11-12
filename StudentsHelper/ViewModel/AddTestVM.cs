using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;

namespace StudentsHelper.ViewModel
{
    public class AddTestVM : BaseViewModel
    {
        //This class refers to AddTestWindow.xaml
        public AddTestVM()
        {
            SaveTestCommand = new SaveTestCommand(this);
        }

        public Test Test { get; set; } = new Test { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };
        public RoomLetters RoomLetters { get; set; } = new RoomLetters();
        public SaveTestCommand SaveTestCommand { get; set; }

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