using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class Lesson
    {

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        private string note = string.Empty;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public Teacher ?Teacher { get; set; }
    }
}
