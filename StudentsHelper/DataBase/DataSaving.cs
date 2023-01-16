using SQLite;
using System;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class DataSaving : DataBaseHelper
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
    }
}