using SQLite;
using System.ComponentModel.DataAnnotations;

namespace StudentsHelper.Model
{
    public class Student
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}