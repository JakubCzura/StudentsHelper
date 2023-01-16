using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Test
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public string Name = string.Empty;

        public DateTime DateOfTest { get; set; } = DateTime.Now;

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

        public int? RoomNumber { get; set; } = null;

        public string RoomLetter { get; set; } = string.Empty;

        public string FullRoomNumber
        {
            get { return $"{RoomNumber}{RoomLetter}"; }
        }

        public string Note { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public string StudentLogin { get; set; } = string.Empty;
    }
}