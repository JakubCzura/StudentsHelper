using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentsHelper.Model
{
    internal class Student : IUser
    {
        
        private int id = 0;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name = string.Empty;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        private string secondName = string.Empty;
        public string SecondName 
        {
            get { return secondName; }
            set { secondName = value; }
        }

        private int age = 0;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string login = string.Empty;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string password = string.Empty;
        public string Password 
        {
            get { return password; }
            set { password = value; }
        }
    }
}
