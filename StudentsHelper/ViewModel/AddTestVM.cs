﻿using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class AddTestVM : INotifyPropertyChanged
    {
        public Test Test { get; set; } = new Test { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public SaveTestCommand SaveTestCommand { get; set; }

        public AddTestVM()
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

        public DateTime DateOfTest
        {
            get { return Test.DateOfTest; }
            set
            {
                Test.DateOfTest = value;
                OnPropertyChanged(nameof(DateOfTest));
            }
        }

        public int? HourOfTest
        {
            get { return Test.HourOfTest; }
            set
            {
                Test.HourOfTest = value;
                OnPropertyChanged(nameof(HourOfTest));
            }
        }

        public int? MinuteOfTest
        {
            get { return Test.MinuteOfTest; }
            set
            {
                Test.MinuteOfTest = value;
                OnPropertyChanged(nameof(MinuteOfTest));
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