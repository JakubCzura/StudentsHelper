using StudentsHelper.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class EditUserProfileCommand : ICommand
    {
        public EditUserProfileCommand(UserProfileVM userProfileVM)
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
            return true;
        }

        public void Execute(object? parameter)
        {
            SetUserDataIsReadonlyFalse();
        }

        private void SetUserDataIsReadonlyFalse()
        {
            UserProfileUserControl.Instance.NameTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.SecondNameTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.AgeTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.LoginTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.CourseTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.SemestrTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.SpecialityTextBox.IsReadOnly = false;
            UserProfileUserControl.Instance.FacultyTextBox.IsReadOnly = false;
        }
    }
}
