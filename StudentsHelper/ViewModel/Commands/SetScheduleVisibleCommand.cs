using StudentsHelper.Schedules;
using StudentsHelper.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SetScheduleVisibleCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            WindowsVisibility.OnHideWindow();
            if (ScheduleVM.Instance != null)
            {
                ScheduleVM.Instance.SetWindowVisible();
                SetSchedule();
            }
        }

        private static void SetSchedule()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.ScheduleWebBrowser.Navigate(ScheduleImporter.GetSchedulePath());
            }
        }
    }
}
