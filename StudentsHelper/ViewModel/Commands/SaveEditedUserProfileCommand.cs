using StudentsHelper.DataBase;
using StudentsHelper.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveEditedUserProfileCommand : ICommand
    {
        public SaveEditedUserProfileCommand(UserProfileVM userProfileVM)
        {
            UserProfileVM = userProfileVM;
        }

        UserProfileVM UserProfileVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (UserProfileUserControl.Instance?.NameTextBox.IsReadOnly == false)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (SaveData.Update(UserProfileVM.Student) && SaveData.Update(UserProfileVM.DegreeCourse))
            {
                if (UserProfileUserControl.Instance?.OldPasswordPasswordBox.Password.Length > 1
                    && UserProfileUserControl.Instance.NewPasswordBox.Password.Length > 1 
                    && UserProfileUserControl.Instance.RepeatedPasswordBox.Password.Length > 1)
                {
                    if (UserProfileVM.Student.Password == UserProfileUserControl.Instance?.OldPasswordPasswordBox.Password
                    && UserProfileUserControl.Instance.NewPasswordBox.Password == UserProfileUserControl.Instance.RepeatedPasswordBox.Password)
                    {
                        UserProfileVM.Student.Password = UserProfileUserControl.Instance.RepeatedPasswordBox.Password;
                        SaveData.Update(UserProfileVM.Student);
                    }
                    else
                    {
                        MessageBox.Show("Hasło nie mogło zostać zmienione, prosimy sprobówać ponownie", "Nie zapisano hasła");
                    }
                }
                MessageBox.Show("Zapisano pomyślnie", "Edytowano informacje");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować informacje ponownie", "Błąd edytowania informacji");
            }
            SetUserDataIsReadonlyTrue();
        }

        private void SetUserDataIsReadonlyTrue()
        {
            UserProfileUserControl.Instance.NameTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.SecondNameTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.AgeTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.LoginTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.CourseTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.SemestrTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.SpecialityTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.FacultyTextBox.IsReadOnly = true;
        }
    }
}
