using MvvmHelpers.Interfaces;
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
    public class GetScheduleCommand : ICommand
    {
        public GetScheduleCommand(ScheduleVM scheduleVM)
        {
            ScheduleVM = scheduleVM;
        }

        ScheduleVM ScheduleVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                await ScheduleDownloader.DownloadScheduleAsync(ScheduleVM.Student.Email, ScheduleVM.Student.Password);
                if (ScheduleUserControl.Instance != null)
                {
                    ScheduleUserControl.Instance.ScheduleWebBrowser.Navigate(ScheduleImporter.GetSchedulePath());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd pobrania planu zajęć");
            }
        }     
    }
}
