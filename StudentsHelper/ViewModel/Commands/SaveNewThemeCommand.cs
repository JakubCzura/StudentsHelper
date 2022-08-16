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
    public class SaveNewThemeCommand : ICommand
    {
        public SaveNewThemeCommand(ThemeChangeVM themeChangeVM)
        {
            ThemeChangeVM = themeChangeVM;
        }

        ThemeChangeVM ThemeChangeVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {           
            if (string.IsNullOrWhiteSpace(ThemeUserControl.Instance?.NewThemeComboBox.Text) == false)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            ChangeTheme();
        }

        void ChangeTheme()
        {
            try
            {
                
                    
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nMotyw nie mógł zostać zmieniony, prosimy sprobówać ponownie", "Nie zapisano motywu");
            }
            finally
            {
                
            }
        }        
    }
}
