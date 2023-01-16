using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Homework
    {
        public Homework()
        {
        }

        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public string LessonName { get; set; } = string.Empty;

        public string TeacherName { get; set; } = string.Empty;

        public string TeacherSecondName { get; set; } = string.Empty;

        public DateTime DateOfEnd { get; set; } = DateTime.Today;
       
        public string TeacherFullName
        {
            get { return $"{TeacherName} {TeacherSecondName}"; }
        }

        public string DateOfEndShort
        {
            get { return DateOfEnd.ToShortDateString(); }
        }

        public string Exercise { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public string StudentLogin { get; set; } = string.Empty;
    }
}