using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    public class Teacher
    {
        private int id = 0;
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string lesson = string.Empty;

        public string Lesson 
        { 
            get { return lesson; } 
            set { lesson = value; } 
        }

        private int studentId = 0;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value.Length < 50 ? value : String.Empty; }
        }

        private string lastName = string.Empty;
        public string LastName       
        { 
            get { return lastName; } 
            set { lastName = value.Length < 50 ? value : String.Empty; } 
        }

        private string degree = string.Empty;
        public string Degree
        {
            get { return degree; }
            set { degree  = value; }
        }

        private int roomNumber;
        public int RoomNumber
        {
            get { return roomNumber;}
            set { roomNumber = value; }
        }

        private string note = string.Empty;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private string studentLogin = string.Empty;
        public string StudentLogin
        {
            get { return studentLogin; }
            set { studentLogin = value; }
        }

        public string TeacherFullName
        {
            get { return Degree + " " + Name + " " + lastName; }
        }
    }
}
