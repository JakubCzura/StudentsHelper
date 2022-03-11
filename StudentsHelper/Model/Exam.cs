using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class Exam
    {
        public Teacher ?Teacher { get; set; }


        private string name = "";
        public string Name
        { 
            get { return name; } 
            set { name = value; } 
        }
    }
}
