using SQLite;
using System;

namespace StudentsHelper.Model
{
    public class Note
    {
        private int id { get; set; } = 0;

        [PrimaryKey, AutoIncrement, NotNull]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime date { get; set; } = DateTime.Now;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string name { get; set; } = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string content { get; set; } = string.Empty;

        public string Content
        {
            get { return content; }
            set { content = value; }
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