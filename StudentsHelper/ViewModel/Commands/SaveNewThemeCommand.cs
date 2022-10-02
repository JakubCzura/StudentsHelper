using StudentsHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StudentsHelper.View.UserControls;

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
                Themes.Themes.SaveTheme(ThemeChangeVM.NewTheme);
                Themes.Themes.SetTheme();
                if (ThemeUserControl.Instance != null)
                {
                    ThemeUserControl.Instance.CurrentTheme.Text = ThemeChangeVM.NewTheme;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nMotyw nie mógł zostać zmieniony, prosimy sprobówać ponownie", "Nie zapisano motywu");
            }
        }
    }
}