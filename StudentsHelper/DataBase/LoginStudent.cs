using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class LoginStudent : DataBaseHelper
    {
        public static bool Login(LoginVM LoginVM)
        {           
            try
            {
                Student Student = new Student();

                //DegreeCourse DegreeCourse = new DegreeCourse()
                //{
                //    StudentLogin = LoginVM.Login,
                //    Course = LoginVM.Course,
                //    Faculty = LoginVM.Faculty,
                //    Speciality = LoginVM.Speciality,
                //    Semester = LoginVM.Semestr
                //};

                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    List<Student>? Students = SQLiteConnection.Table<Student>().ToList();
                    if(Students.Any())
                    {
                        Student = Students.Find(s => s.Password == LoginVM.Password && s.Login == LoginVM.Login);

                    }
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie się zarejestrować", "Błąd rejestracji");
                return false;
            }
        }
    }
}
