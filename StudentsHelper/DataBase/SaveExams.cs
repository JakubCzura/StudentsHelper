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
    public class SaveExams : DataBaseHelper
    {
        public static bool Save(Exam Exam)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Exam>();
                    SQLiteConnection.Insert(Exam);
                    if(ExamsVM.Instance != null)
                    {
                        ExamsVM.Instance.Exams = LoginStudent.GetExamsData();                    }
                    
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie dodać egzamin", "Błąd dodania egzaminu");
                return false;
            }
        }
    }
}
