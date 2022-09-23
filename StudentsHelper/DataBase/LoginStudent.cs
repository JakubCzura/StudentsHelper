using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows;
using System.Collections.ObjectModel;

namespace StudentsHelper.DataBase
{
    public class LoginStudent : DataBaseHelper
    {
        public static bool Login(LoginVM LoginVM)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    Student? Student = SQLiteConnection.Table<Student>().First(s => s.Login == LoginVM.Login);
                    if (Student != null)
                    {
                        if(Hasher.VerifyPassword(LoginVM.Password, Student.Password))
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

        public static Student GetStudentData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    Student Student = SQLiteConnection.Table<Student>().First(s => s.Id == StudentId);
                    if (Student != null)
                    {
                        return Student;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static DegreeCourse GetDegreeCourseData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    DegreeCourse DegreeCourse = SQLiteConnection.Table<DegreeCourse>().First(s => s.Id == StudentId);
                    if (DegreeCourse != null)
                    {
                        return DegreeCourse;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Exam> GetExamsData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    List<Exam> ExamsList = SQLiteConnection.Table<Exam>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Exam> Exams = new ObservableCollection<Exam>(ExamsList);
                    if (Exams != null)
                    {
                        return Exams;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Test> GetTestsData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    List<Test> TestsList = SQLiteConnection.Table<Test>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Test> Tests = new ObservableCollection<Test>(TestsList);

                    if (Tests != null)
                    {
                        return Tests;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Homework> GetHomeworkData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    List<Homework> HomeworkList = SQLiteConnection.Table<Homework>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Homework> Homework = new ObservableCollection<Homework>(HomeworkList);
                    if (Homework != null)
                    {
                        return Homework;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Teacher> GetTeachersData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    List<Teacher> TeachersList = SQLiteConnection.Table<Teacher>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Teacher> Teachers = new ObservableCollection<Teacher>(TeachersList);
                    if (Teachers != null)
                    {
                        return Teachers;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Note> GetNotesData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    List<Note> NotesList = SQLiteConnection.Table<Note>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Note> Notes = new ObservableCollection<Note>(NotesList);
                    if (Notes != null)
                    {
                        return Notes;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }
    }
}
