using StudentsHelper.Themes;
using StudentsHelper.View.UserControls;
using StudentsHelper.ViewModel.Commands;
using StudentsHelper.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class ThemeChangeVM : INotifyPropertyChanged, IVisibility
    {
        //This class refers to ThemesUserControl.xaml
        public ThemeChangeVM()
        {
            Instance = this;
            WindowsVisibility.HideSettings += SetHidden;
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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetHidden()
        {
            if (ThemeUserControl.Instance != null)
            {
                ThemeUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetVisible()
        {
            if (ThemeUserControl.Instance != null)
            {
                ThemeUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
