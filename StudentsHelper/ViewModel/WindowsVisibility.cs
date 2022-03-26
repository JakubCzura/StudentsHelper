using StudentsHelper.UserControls;
using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class WindowsVisibility
    {
        public Action HideUserControlsEventHandler? HideUserControls;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void HideMainWindowUserControls()
        {
            ExamsUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            TestsUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
