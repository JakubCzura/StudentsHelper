using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using StudentsHelper.ViewModel;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class SaveHomework : DataBaseHelper
    {
        public static bool Save(Homework Homework)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Homework>();
                    SQLiteConnection.Insert(Homework);
                    if (HomeworkVM.Instance != null)
                    {
                        HomeworkVM.Instance.Homework = LoginStudent.GetHomeworkData();
                    }
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie dodać pracę domową", "Błąd dodania pracy domowej");
                return false;
            }
        }
    }
}
