using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.View.UserControls;
using System;
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

        private UserProfileVM UserProfileVM { get; set; }

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
            try
            {
                if (StudentDataValidator.ValidateStudentData(UserProfileVM.Student) && DegreeCourseDataValidator.ValidateDegreeCourseData(UserProfileVM.DegreeCourse))
                {
                    if (DataUpdating.Update(UserProfileVM.Student) && DataUpdating.Update(UserProfileVM.DegreeCourse))
                    {
                        MessageBox.Show("Zapisano pomyślnie", "Edytowano informacje");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj edytować informacje ponownie", "Błąd edytowania informacji");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nSpróbuj edytować informacje ponownie", "Błąd edytowania informacji");
            }
            finally
            {
                SetUserDataIsReadonlyTrue();
            }
        }

        private void SetUserDataIsReadonlyTrue()
        {
            UserProfileUserControl.Instance.NameTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.SecondNameTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.EmailTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.AgeTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.LoginTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.CourseTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.SemestrTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.SpecialityTextBox.IsReadOnly = true;
            UserProfileUserControl.Instance.FacultyTextBox.IsReadOnly = true;
        }
    }
}