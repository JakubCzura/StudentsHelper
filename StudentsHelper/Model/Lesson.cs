using SQLite;

namespace StudentsHelper.Model
{
    public class Lesson
    {
        private int id;

        [PrimaryKey, AutoIncrement, NotNull]
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