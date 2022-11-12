using StudentsHelper.View.Windows;
using System;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowScheduleInstructionWindowCommand : ICommand
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
            ScheduleInstructionWindow ScheduleInstructionWindow = new ScheduleInstructionWindow();
            ScheduleInstructionWindow.Show();
        }
    }
}