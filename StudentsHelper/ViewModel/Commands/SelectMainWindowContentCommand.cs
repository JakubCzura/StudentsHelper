using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SelectMainWindowContentCommand : ICommand
    {
        public SelectMainWindowContentCommand(StudentsHelperVM studentsHelperVM)
        {
            StudentsHelperVM = studentsHelperVM;
        }

        public StudentsHelperVM StudentsHelperVM { get; set; }

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
            if (parameter != null)
            {
                try
                {
                    if (parameter.ToString() == "Schedule")
                    {
                        ScheduleVM.InitializeScheduleWebBrowser();
                    }
                    StudentsHelperVM.SelectedMainWindowContent = parameter.ToString() switch
                    {
                        "WelcomeScreen" => new WelcomeScreenVM(),
                        "Tests" => new TestsVM(),
                        "Exams" => new ExamsVM(),
                        "Teachers" => new TeachersVM(),
                        "Schedule" => new ScheduleVM(),
                        "UserProfile" => new UserProfileVM(),
                        "Homework" => new HomeworkVM(),
                        "Notes" => new NotesVM(),
                        "Settings" => new SettingsVM(),
                        _ => new WelcomeScreenVM(),
                    };
                    if (parameter.ToString() != "Schedule")
                    {
                        ScheduleVM.DisposeScheduleWebBrowser();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}