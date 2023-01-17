using SQLite;
using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class StudentRegistration : DataBaseHelper
    {
        public bool Register(Student student, DegreeCourse degreeCourse)
        {
            try
            {
                using SQLiteConnection SQLiteConnection = new(DataBasePath);
                SQLiteConnection.CreateTable<Student>();
                SQLiteConnection.CreateTable<DegreeCourse>();
                Student? StudentTMP = SQLiteConnection.Table<Student>().FirstOrDefault(s => s.Login == student.Login);
                if (StudentTMP != null)
                {
                    MessageBox.Show($"Istnieje już użytkownik o podanym loginie\nPodaj inny login", "LogIn jest już używany");
                    return false;
                }
                else
                {
                    SQLiteConnection.Insert(student);
                    degreeCourse.StudentId = student.Id;
                    SQLiteConnection.Insert(degreeCourse);
                    return true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie się zarejestrować", "Błąd rejestracji");
                return false;
            }
        }
    }
}