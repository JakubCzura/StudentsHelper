using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Homework
    {
        public Homework()
        {
            DateOfEnd = DateTime.Now;
        }

        private int id = 0;

        [PrimaryKey, AutoIncrement, NotNull]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string lessonName = string.Empty;

        public string LessonName
        {
            get { return lessonName; }
            set { lessonName = value; }
        }

        private string teacherName = string.Empty;

        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }

        private string teacherSecondName = string.Empty;

        public string TeacherSecondName
        {
            get { return teacherSecondName; }
            set { teacherSecondName = value; }
        }

        private DateTime dateOfEnd = DateTime.Today;

        public DateTime DateOfEnd
        {
            get { return dateOfEnd; }
            set { dateOfEnd = value; }
        }

        public string TeacherFullName
        {
            get { return $"{TeacherName} {TeacherSecondName}"; }
        }

        public string DateOfEndShort
        {
            get { return DateOfEnd.ToShortDateString(); }
        }

        private string exercise = string.Empty;

        public string Exercise
        {
            get { return exercise; }
            set { exercise = value; }
        }

        private string note = string.Empty;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private int studentId = 0;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        private string studentLogin = string.Empty;

        public string StudentLogin
        {
            get { return studentLogin; }
            set { studentLogin = value; }
        }
    }
}