using SQLite;
using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class LoggingInManager : DataBaseHelper
    {
        public static bool LogIn(string password, string login)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    Student? Student = SQLiteConnection.Table<Student>().FirstOrDefault(s => s.Login == login);
                    if (Student != null)
                    {
                        if (Hasher.VerifyPassword(password, Student.Password))
                        {
                            StudentId = Student.Id;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie się zalogować", "Błąd logowania");
                return false;
            }
        }
    }
}
