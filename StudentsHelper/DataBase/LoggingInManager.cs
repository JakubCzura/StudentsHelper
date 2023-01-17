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
        public static bool LogIn(LoginVM LoginVM)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    Student? Student = SQLiteConnection.Table<Student>().FirstOrDefault(s => s.Login == LoginVM.Login);
                    if (Student != null)
                    {
                        if (Hasher.VerifyPassword(LoginVM.Password, Student.Password))
                        {
                            StudentId = Student.Id;
                            StudentLogin = Student.Login;
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
