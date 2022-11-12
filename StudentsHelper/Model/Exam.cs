using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Exam
    {
        public Exam()
        {
            DateOfExam = DateTime.Now;
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

        private DateTime dateOfExam = DateTime.Today;

        public DateTime DateOfExam
        {
            get { return dateOfExam; }
            set { dateOfExam = value; }
        }

        public string DateOfExamShort
        {
            get { return DateOfExam.ToShortDateString(); }
        }

        private int? hourOfExam = null;

        public int? HourOfExam
        {
            get { return hourOfExam; }
            set
            {
                if (value >= 0 && value <= 24)
                {
                    hourOfExam = value;
                }
            }
        }

        private int? minuteOfExam = null;

        public int? MinuteOfExam
        {
            get { return minuteOfExam; }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    minuteOfExam = value;
                }
            }
        }

        public string FullHourOfExam
        {
            get { return $"{HourOfExam}:{MinuteOfExam}"; }
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