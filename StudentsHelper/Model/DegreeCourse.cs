using SQLite;

namespace StudentsHelper.Model
{
    public class DegreeCourse
    {

        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public int StudentId { get; set; }

        //Kierunek
        public string Course { get; set; } = string.Empty;

        //Semestr
        public int Semester { get; set; }

        //Specjalizacja
        public string Speciality { get; set; } = string.Empty;

        //Wydział
        public string Faculty { get; set; } = string.Empty;

    }
}