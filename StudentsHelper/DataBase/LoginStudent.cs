using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class LoginStudent : DataBaseHelper
    {
        public static bool IfStudentExists = false;

        public static bool Login(LoginVM LoginVM)
        {
            try
            {
                Student? Student = null;

                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    Student = SQLiteConnection.Table<Student>().First(s => s.Login == LoginVM.Login && s.Password == LoginVM.Password);
                    if (Student != null)
                    {
                        IfStudentExists = true;
                        return true;
                    }
                }
                IfStudentExists = false;
                return false;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj ponownie się zarejestrować", "Błąd rejestracji");
                IfStudentExists=false;
                return false;
            }
        }

        public static bool GetStudentData(LoginVM LoginVM)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(DataBasePath))
                {
                    if(StudentsHelperVM.StudentsHelperVMInstance != null)
                    {
                        StudentsHelperVM.StudentsHelperVMInstance.Student = SQLiteConnection.Table<Student>().First(s => s.Login == LoginVM.Login && s.Password == LoginVM.Password);
                        if (StudentsHelperVM.StudentsHelperVMInstance.Student != null)
                        {
                            return true;
                        }
                    }                  
                }
                return false;
            }

            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return false;
            }
        }
    }
}
