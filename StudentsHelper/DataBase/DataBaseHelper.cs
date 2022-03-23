using SQLite;
using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class DataBaseHelper
    {
        private static string DataBaseName { get; set; } = "StudentsHelperDataBase.db";
        private static string FolderPath { get; set; } = Environment.CurrentDirectory;
    
        private static string DataBasePath { get; set; } = System.IO.Path.Combine(FolderPath, DataBaseName);

        public static void RegisterStudent(RegisterWindowVM RegisterWindowVM)
        {
            MessageBox.Show(DataBasePath);
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
                SQLiteConnection.Insert(Student);
                SQLiteConnection.CreateTable<DegreeCourse>();
                SQLiteConnection.Insert(DegreeCourse);
            }          
        }        
    }
}
