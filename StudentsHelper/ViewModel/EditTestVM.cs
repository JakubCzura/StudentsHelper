﻿using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class EditTestVM : BaseViewModel
    {
        public EditTestVM()
        {
            SelectedTest = TestsVM.Instance.SelectedTest;

            SaveEditedTestCommand = new SaveEditedTestCommand(this);
            RoomLetters = new RoomLetters();
            Instance = this;
        }

        public static EditTestVM? Instance { get; set; }

        public RoomLetters RoomLetters { get; set; } 
        public ICommand SaveEditedTestCommand { get; private set; }

        public string Name
        {
            get { return SelectedTest.Name; }
            set { SelectedTest.Name = value; OnPropertyChanged(Name); }
        }

        public DateTime DateOfTest
        {
            get { return SelectedTest.DateOfTest; }
            set { SelectedTest.DateOfTest = value; OnPropertyChanged(nameof(DateOfTest)); }
        }

        public int? HourOfTest
        {
            get { return SelectedTest.HourOfTest; }
            set { SelectedTest.HourOfTest = value; OnPropertyChanged(nameof(HourOfTest)); }
        }

        public int? MinuteOfTest
        {
            get { return SelectedTest.MinuteOfTest; }
            set { SelectedTest.MinuteOfTest = value; OnPropertyChanged(nameof(MinuteOfTest)); }
        }

        public int? RoomNumber
        {
            get { return SelectedTest.RoomNumber; }
            set { SelectedTest.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }

        public string RoomLetter
        {
            get { return SelectedTest.RoomLetter; }
            set { SelectedTest.RoomLetter = value; OnPropertyChanged(nameof(RoomLetter)); }
        }

        public List<string> Letters
        {
            get { return RoomLetters.Letters; }
            set { RoomLetters.Letters = value; OnPropertyChanged(nameof(Letters)); }
        }

        public string Note
        {
            get { return SelectedTest.Note; }
            set { SelectedTest.Note = value; OnPropertyChanged(Note); }
        }

        private Test selectedTest;

        public Test SelectedTest
        {
            get { return selectedTest; }
            set { selectedTest = value; OnPropertyChanged(nameof(SelectedTest)); }
        }
    }
}