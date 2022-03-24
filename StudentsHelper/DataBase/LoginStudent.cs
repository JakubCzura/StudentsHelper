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
                Student? Student = null;

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
                    Student = SQLiteConnection.Table<Student>().First(s => s.Login == LoginVM.Login && s.Password == LoginVM.Password);
                    if(Student != null)
                    {
                        if (StudentsHelperVM.StudentsHelperVMInstance != null)
                            StudentsHelperVM.StudentsHelperVMInstance.Student = Student;
                        return true;
                    }              
                }
                return false;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie się zarejestrować", "Błąd rejestracji");
                return false;
            }
        }
    }
}
