using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class Exam
    {       
        private string name = "";
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

        public Teacher? Teacher { get; set; }
    }
}
