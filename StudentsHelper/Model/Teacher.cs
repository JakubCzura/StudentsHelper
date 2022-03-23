using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class Teacher
    {
        public Teacher() { }
        public Teacher(string name, string lastName, string degree, int roomNumber, string note)
        {
            Name = name;
            LastName = lastName;
            Degree = degree;
            RoomNumber = roomNumber;
            Note = note;
        }

        private int studentid = 0;

        public int Studentid
        {
            get { return studentid; }
            set { studentid = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastName = string.Empty;
        public string LastName       
        { 
            get { return lastName; } 
            set { lastName = value; } 
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

        private int id = 0;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return Degree + " " + Name + " " + lastName;
        }
    }
}
