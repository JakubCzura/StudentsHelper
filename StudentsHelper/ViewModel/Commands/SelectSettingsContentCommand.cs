using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SelectSettingsContentCommand : ICommand
    {
        public SelectSettingsContentCommand(SettingsVM settingsVM)
        {
            SettingsVM = settingsVM;
        }

        public SettingsVM SettingsVM { get; set; }
        
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
            if (parameter != null)
            {
                try
                {
                    SettingsVM.SelectedSettingsContent = parameter.ToString() switch
                    {
                        "Password" => new PasswordChangeVM(),
                        "Theme" => new ThemeChangeVM(),   
                        _ => new PasswordChangeVM(),
                    };
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
