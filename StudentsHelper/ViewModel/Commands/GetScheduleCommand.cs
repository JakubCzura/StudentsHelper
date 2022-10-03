using StudentsHelper.DataValidators;
using StudentsHelper.Schedules;
using StudentsHelper.View;
using StudentsHelper.View.UserControls;
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
            if (ScheduleUserControl.Instance != null)
            {
                if (string.IsNullOrEmpty(ScheduleUserControl.Instance.UserPasswordPasswordBox.Password) == false)
                { 
                    return true; 
                }
            }
            return false;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                ScheduleVM.IsGetScheduleButtonEnabled = false;
                if (ScheduleUserControl.Instance != null)
                {
                    ScheduleUserControl.Instance.UserPasswordPasswordBox.IsEnabled = false;
                    if (await ScheduleDownloader.DownloadScheduleAsync(ScheduleVM.Student.Email, ScheduleUserControl.Instance.UserPasswordPasswordBox.Password))
                    {
                        if (await ScheduleDownloader.IsScheduleDownloadedAsync() == true)
                        {
                            ScheduleImporter.SetSchedule();
                        }
                        else
                        {
                            MessageBox.Show("Jeśli plan zajęć nie załadował się automatycznie, proszę jeszcze raz kliknąć przycisk\n" +
                                "Pobierz plan w celu pobrania planu zajęć lub\n" +
                                "Plan zajęć w celu odświeżenia okna");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd pobrania planu zajęć");
            }
            finally
            {
                ScheduleVM.IsGetScheduleButtonEnabled = true;
                if (ScheduleUserControl.Instance != null)
                {
                    ScheduleUserControl.Instance.UserPasswordPasswordBox.IsEnabled = true;
                    ScheduleUserControl.Instance.UserPasswordPasswordBox.Password = String.Empty;
                }
            }
        }
    }
}
