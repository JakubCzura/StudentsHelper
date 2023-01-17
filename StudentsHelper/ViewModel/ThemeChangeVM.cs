using CommunityToolkit.Mvvm.Input;
using StudentsHelper.Themes;
using StudentsHelper.View.UserControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class ThemeChangeVM : BaseViewModel
    {
        //This class refers to ThemesUserControl.xaml
        public ThemeChangeVM()
        {
            Instance = this;
            SaveNewThemeCommand = new RelayCommand(SaveNewTheme);
            Theme = ThemesManager.ReadTheme();
        }

        private void SaveNewTheme()
        {
            if (string.IsNullOrWhiteSpace(ThemeUserControl.Instance?.NewThemeComboBox.Text) == false)
            {
                try
                {
                    ThemesManager.SaveTheme(NewTheme);
                    ThemesManager.SetTheme();
                    if (ThemeUserControl.Instance != null)
                    {
                        ThemeUserControl.Instance.CurrentTheme.Text = NewTheme;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}\nMotyw nie mógł zostać zmieniony, prosimy sprobówać ponownie", "Nie zapisano motywu");
                }
            }
        }

        public static ThemeChangeVM? Instance { get; set; }

        public ICommand SaveNewThemeCommand { get; set; }

        private string theme = String.Empty;

        public string Theme
        {
            get { return theme; }
            set { theme = value; OnPropertyChanged(Theme); }
        }

        private string newTheme = string.Empty;

        public string NewTheme
        {
            get { return newTheme; }
            set { newTheme = value; OnPropertyChanged(NewTheme); }
        }

        private List<string> themes = ThemesManager.GetThemes();

        public List<string> Themes
        {
            get { return themes; }
            set { themes = value; OnPropertyChanged(nameof(Themes)); }
        }
    }
}