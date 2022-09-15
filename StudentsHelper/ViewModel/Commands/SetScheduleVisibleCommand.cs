using StudentsHelper.Schedules;
using StudentsHelper.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (ScheduleVM.Instance != null)
            {
                Geckodriver.Geckodriver.CopyGeckodriverToDebugDirectory();
                WindowsVisibility.OnHideWindow();
                ScheduleVM.Instance.SetWindowVisible();
                try
                {
                    ScheduleImporter.SetSchedule();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
