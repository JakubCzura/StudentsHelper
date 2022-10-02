using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.UserControls;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using StudentsHelper.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class SettingsVM : IWindowVisibility
    {
        //This class refers to SettingsUserControl.xaml
        public SettingsVM()
        {
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
            SetPasswordChangeVisibleCommand = new SetPasswordChangeVisibleCommand();
            SetThemeChangeVisibleCommand = new SetThemeChangeVisibleCommand();
        }

        public static SettingsVM? Instance { get; set; }

        public SetPasswordChangeVisibleCommand SetPasswordChangeVisibleCommand { get; set; }
        
        public SetThemeChangeVisibleCommand SetThemeChangeVisibleCommand { get; set; }
                    

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
