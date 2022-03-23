using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Model
{
    internal class DegreeCourse
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string studentLogin = string.Empty;

        public string StudentLogin
        {
            get { return studentLogin; }
            set { studentLogin = value; }
        }


        private int studentid = 0;

        public int Studentid
        {
            get { return studentid; }
            set { studentid = value; }
        }

        //Kierunek
        private string course = string.Empty;

        public string Course
        {
            get { return course; }
            set { course = value; }
        }

        //Semestr
        private int semester = 0;

        public int Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        //Specjalizacja
        private string speciality = string.Empty;

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }

        //Wydział
        private string faculty = string.Empty;

        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

    }
}
