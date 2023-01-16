using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public string StudentLogin { get; set; } = string.Empty;
    }
}