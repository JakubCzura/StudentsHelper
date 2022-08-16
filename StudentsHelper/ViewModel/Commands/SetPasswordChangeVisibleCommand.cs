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
        public SetPasswordChangeVisibleCommand(SettingsVM settingsVM)
        {
            SettingsVM = settingsVM;
        }
        SettingsVM SettingsVM { get; set; }

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
               
        }
    }
}
