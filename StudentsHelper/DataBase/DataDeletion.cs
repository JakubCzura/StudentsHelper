using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class DataDeletion : DataBaseHelper
    {
        public static bool Delete<T>(T Data) where T : class
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
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
    }
}
