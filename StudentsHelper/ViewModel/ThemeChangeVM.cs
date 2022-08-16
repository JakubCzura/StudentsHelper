using StudentsHelper.Themes;
using StudentsHelper.UserControls;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class ThemeChangeVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to ThemesUserControl.xaml

        public static ThemeChangeVM? Instance { get; set; }

        public SaveNewThemeCommand SaveNewThemeCommand { get; set; }
        public ThemeChangeVM()
        {
            Instance = this;
            WindowsVisibility.HideSettings += SetWindowHidden;
            SaveNewThemeCommand = new SaveNewThemeCommand(this);
        }

        string theme = string.Empty;
       
        public string Theme
        {
            get { return theme; }
            set { theme = value; OnPropertyChanged(Theme); }
        }

        string newTheme = string.Empty;

        public string NewTheme
        {
            get { return newTheme; }
            set { newTheme = value; OnPropertyChanged(NewTheme); }
        }

        private List<string> themes = EnumThemes.GetThemes();

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

        public void SetWindowHidden()
        {
            if (ThemeUserControl.Instance != null)
            {
                ThemeUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (ThemeUserControl.Instance != null)
            {
                ThemeUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
