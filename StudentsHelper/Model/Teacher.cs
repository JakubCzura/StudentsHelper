using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class Teacher
    {   
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
    }
}
