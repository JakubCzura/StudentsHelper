using SQLite;
using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class RegisterStudent : DataBaseHelper
    {
        public static bool Register(RegisterWindowVM RegisterWindowVM)
        {
            try
            {
                Student Student = RegisterWindowVM.Student;

                DegreeCourse DegreeCourse = RegisterWindowVM.DegreeCourse;
                {
                    StudentLogin = RegisterWindowVM.Login;
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