﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    public class Test
    {
        public Test() { DateOfTest = DateTime.Now; }
        public Test(string name, int roomNumber, string note, int hourOfExam, int minuteOfExam, int studentId, DateTime dateOfExam)
        {
            Name = name;
            DateOfTest = dateOfExam;
            RoomNumber = roomNumber;
            Note = note;
            HourOfTest = hourOfExam;
            MinuteOfTest = minuteOfExam;
            StudentId = studentId;
        }

        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime dateOfTest;
        public DateTime DateOfTest
        {
            get { return dateOfTest; }
            set { dateOfTest = value; }
        }
        public string DateOfTestShort
        {
            get { return DateOfTest.ToShortDateString(); }
        }

        private int? hourOfTest = null;
        public int? HourOfTest
        {
            get { return hourOfTest; }
            set
            {
                if (value >= 0 && value <= 24)
                {
                    hourOfTest = value;
                }
            }
        }

        private int? minuteOfTest = null;

        public int? MinuteOfTest
        {
            get { return minuteOfTest; }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    minuteOfTest = value;
                }
            }
        }

        public string FullHourOfTest
        {
            get { return $"{HourOfTest}:{MinuteOfTest}"; }
        }

        private int? roomNumber = null;
        public int? RoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value > 0 && value < 100000)
                {
                    roomNumber = value;
                }
            }
        }

        private string note = string.Empty;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private int studentId = 0;
        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        private string studentLogin = string.Empty;
        public string StudentLogin
        {
            get { return studentLogin; }
            set { studentLogin = value; }
        }
    }
}