using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    public class Exam
    {
        public Exam() { DateOfExam = DateTime.Now; }
        public Exam(string name, int roomNumber, string note, int hourOfExam, int minuteOfExam, int studentId, DateTime dateOfExam)
        {
            Name = name;
            DateOfExam = dateOfExam;
            RoomNumber = roomNumber;
            Note = note;
            HourOfExam = hourOfExam;
            MinuteOfExam = minuteOfExam;
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

        private DateTime dateOfExam;
        public DateTime DateOfExam
        {
            get { return dateOfExam; }
            set { dateOfExam = value; }
        }
        public string DateOfExamShort
        {
            get { return DateOfExam.ToShortDateString(); }
        }

        private int hourOfExam;
        public int HourOfExam
        {
            get { return hourOfExam; }
            set { hourOfExam = value; }
        }

        private int minuteOfExam;

        public int MinuteOfExam
        {
            get { return minuteOfExam; }
            set { minuteOfExam = value; }
        }

        private int roomNumber;
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
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
