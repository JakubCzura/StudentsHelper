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
       
        public ThemeChangeVM()
        {
            Instance = this;
            WindowsVisibility.HideSettings += SetWindowHidden;
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetWindowHidden()
        {
            if (SettingsUserControl.Instance != null)
            {
                SettingsUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (SettingsUserControl.Instance != null)
            {
                SettingsUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
