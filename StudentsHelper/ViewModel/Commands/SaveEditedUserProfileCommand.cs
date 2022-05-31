using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return false;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
