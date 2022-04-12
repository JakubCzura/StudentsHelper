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
    public class SaveNote : DataBaseHelper
    {
        public static bool Save(Note Note)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    SQLiteConnection.CreateTable<Note>();
                    SQLiteConnection.Insert(Note);
                    if (NotesVM.Instance != null)
                    {
                        NotesVM.Instance.Notes = LoginStudent.GetNotesData();
                    }
                }
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie dodać kolokwium", "Błąd dodania kolokwium");
                return false;
            }
        }
    }
}
