using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class Exam
    {        
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

        public Teacher? Teacher { get; set; }
    }
}
