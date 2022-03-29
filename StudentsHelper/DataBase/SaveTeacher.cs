using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows;
using StudentsHelper.ViewModel;

namespace StudentsHelper.DataBase
{
    public class SaveTeacher : DataBaseHelper
    {
        public static bool Save(Teacher Teacher)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Teacher>();
                    SQLiteConnection.Insert(Teacher);
                    if (TeachersVM.Instance != null)
                    {
                        TeachersVM.Instance.Teachers = LoginStudent.GetTeachersData();
                    }
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie dodać wykładowcę", "Błąd dodania wykładowcy");
                return false;
            }
        }
    }
}
