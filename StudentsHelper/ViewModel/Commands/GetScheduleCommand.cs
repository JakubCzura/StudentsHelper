using MvvmHelpers.Interfaces;
using StudentsHelper.Schedules;
using StudentsHelper.UserControls;
using StudentsHelper.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
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
                if (await ScheduleDownloader.DownloadScheduleAsync(ScheduleVM.Student.Email, ScheduleVM.Student.Password))
                {
                    if (await ScheduleDownloader.IsScheduleDownloadedAsync() == true)
                    {
                        MessageBox.Show("działa");
                        ScheduleImporter.SetSchedule();
                    }
                    else
                    {
                        MessageBox.Show("nie działa");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd pobrania planu zajęć");
            }                           
        }
        
        private void ClickLessonsButton()
        {
            MainWindow.Instance?.LessonsButton.Command.Execute(MainWindow.Instance.LessonsButton.CommandParameter);
        }
    }
}
