using SQLite;

namespace StudentsHelper.Model
{
    public class Teacher
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public string Lesson { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Degree { get; set; } = string.Empty;

        public int RoomNumber { get; set; } 

        public string Note { get; set; } = string.Empty;

        public string TeacherFullName
        {
            get { return Degree + " " + Name + " " + LastName; }
        }
    }
}