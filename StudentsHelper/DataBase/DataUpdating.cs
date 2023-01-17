using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class DataUpdating : DataBaseHelper
    {
        public static bool Update<T>(T Data) where T : class
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
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
