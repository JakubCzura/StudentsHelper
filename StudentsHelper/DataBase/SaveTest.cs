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
    public class SaveTest : DataBaseHelper
    {
        public static bool Save(Test Test)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Test>();
                    SQLiteConnection.Insert(Test);
                    if (TestVM.Instance != null)
                    {
                        TestVM.Instance.Tests = LoginStudent.GetTestsData();
                    }
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
