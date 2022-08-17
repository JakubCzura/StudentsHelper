using StudentsHelper.DataBase;
using StudentsHelper.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace StudentsHelper.ViewModel.Commands
{
    public class SetPasswordChangeVisibleCommand : ICommand
    {
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
            SetPasswordEmpty();
            WindowsVisibility.OnHideSettings();
            if (PasswordChangeVM.Instance != null)
            {
                PasswordChangeVM.Instance.SetWindowVisible();
            }
        }

        private void SetPasswordEmpty()
        {
            PasswordChangeUserControl.Instance.OldPasswordBox.Password = string.Empty;
            PasswordChangeUserControl.Instance.NewPasswordBox.Password = string.Empty;
            PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password = string.Empty;
        }
    }
}
