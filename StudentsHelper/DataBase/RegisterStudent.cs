using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsHelper.Model;
using SQLite;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class RegisterStudent : DataBaseHelper
    {
        public static bool Register(RegisterWindowVM RegisterWindowVM)
        {
            try
            {
                Student Student = new Student()
                {
                    Name = RegisterWindowVM.Name,
                    SecondName = RegisterWindowVM.SecondName,
                    Age = RegisterWindowVM.Age,
                    Login = RegisterWindowVM.Login,
                    Password = RegisterWindowVM.Password
                };

                DegreeCourse DegreeCourse = new DegreeCourse()
                {
                    StudentLogin = RegisterWindowVM.Login,
                    Course = RegisterWindowVM.Course,
                    Faculty = RegisterWindowVM.Faculty,
                    Speciality = RegisterWindowVM.Speciality,
                    Semester = RegisterWindowVM.Semestr
                };

                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Student>();
                    SQLiteConnection.CreateTable<DegreeCourse>();
                    Student? StudentTMP = SQLiteConnection.Table<Student>().FirstOrDefault(s => s.Login == RegisterWindowVM.Login);
                    if (StudentTMP != null)
                    {
                        MessageBox.Show($"Istnieje już użytkownik o podanym loginie\nPodaj inny login", "Login jest już używany");
                        return false;
                    }
                }

                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.Insert(Student);
                    SQLiteConnection.Insert(DegreeCourse);
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
