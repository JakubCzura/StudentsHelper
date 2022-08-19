using SQLite;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
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
        private static string DataBaseName { get; } = "StudentsHelperDataBase.db";
       
        private static readonly string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create);

        protected static string DataBasePath { get; set; } = Path.Combine(FolderPath, DataBaseName);

        public static int StudentId { get; set; } = -1;

        public static string StudentLogin { get; set; } = string.Empty;
        
        public static void CreateEmptyDataBase()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Student>();
                    SQLiteConnection.CreateTable<DegreeCourse>();
                    SQLiteConnection.CreateTable<Homework>();
                    SQLiteConnection.CreateTable<Exam>();
                    SQLiteConnection.CreateTable<Test>();
                    SQLiteConnection.CreateTable<Lesson>();
                    SQLiteConnection.CreateTable<Teacher>();
                    SQLiteConnection.CreateTable<Note>();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\nZalecamy zrestartowanie aplikacji", "Błąd utworzenia bazy danych");
            }
        }
    }
}
