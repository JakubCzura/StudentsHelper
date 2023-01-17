using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Exam
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime DateOfExam { get; set; } = DateTime.Now;

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

        public int? RoomNumber { get; set; } = null;

        public string RoomLetter { get; set; } = string.Empty;

        public string FullRoomNumber
        {
            get { return $"{RoomNumber}{RoomLetter}"; }
        }

        public string Note { get; set; } = string.Empty;

        public int StudentId { get; set; }
    }
}