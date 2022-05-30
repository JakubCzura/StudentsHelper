using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SQLite;
using StudentsHelper.Model;
using StudentsHelper.ViewModel;

namespace StudentsHelper.DataBase
{
    public class SaveData : DataBaseHelper
    {
        public static bool Save<T>(T Data) where T : class
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<T>();
                    SQLiteConnection.Insert(Data);
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie dodać informację", "Błąd dodania informacji");
                return false;
            }
        }

        public static bool Delete<T>(T Data) where T : class
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.Delete(Data); 
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie skasować treść", "Błąd kasowania danych");
                return false;
            }
        }

        public static bool Update<T>(T Data) where T : class
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.Update(Data);
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie edytować treść", "Błąd edytowania danych");
                return false;
            }
        }
    }
}
