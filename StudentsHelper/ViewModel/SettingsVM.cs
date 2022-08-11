using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.UserControls;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class SettingsVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to SettingsUserControl.xaml

        public static SettingsVM? Instance { get; set; }

        public SettingsVM()
        {          
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
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
