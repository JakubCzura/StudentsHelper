using SQLite;

namespace StudentsHelper.Model
{
    public class DegreeCourse
    {
        private int id;

        [PrimaryKey, AutoIncrement, NotNull]
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

        private int studentId = 0;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
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