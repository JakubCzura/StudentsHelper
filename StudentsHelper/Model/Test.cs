using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Test
    {
        public Test()
        {
            DateOfTest = DateTime.Now;
        }

        private int id;

        [PrimaryKey, AutoIncrement, NotNull]
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

        private DateTime dateOfTest = DateTime.Today;

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
            set { roomNumber = value; }
        }

        private string roomLetter = String.Empty;

        public string RoomLetter
        {
            get { return roomLetter; }
            set { roomLetter = value; }
        }

        public string FullRoomNumber
        {
            get { return $"{RoomNumber}{RoomLetter}"; }
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