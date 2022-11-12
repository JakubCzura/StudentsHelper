using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;

namespace StudentsHelper.ViewModel
{
    public class ThemeChangeVM : BaseViewModel
    {
        //This class refers to ThemesUserControl.xaml
        public ThemeChangeVM()
        {
            Instance = this;
            SaveNewThemeCommand = new SaveNewThemeCommand(this);
            Theme = StudentsHelper.Themes.Themes.ReadTheme();
        }

        public static ThemeChangeVM? Instance { get; set; }

        public SaveNewThemeCommand SaveNewThemeCommand { get; set; }

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

        private List<string> themes = StudentsHelper.Themes.Themes.GetThemes();

        public List<string> Themes
        {
            get { return themes; }
            set { themes = value; OnPropertyChanged(nameof(Themes)); }
        }
    }
}