using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    public class Lesson
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
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
        
        private string note = string.Empty;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
