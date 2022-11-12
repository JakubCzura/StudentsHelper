using StudentsHelper.View.Windows;
using System;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowEditHomeworkCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (HomeworkVM.Instance?.Homework != null && HomeworkVM.Instance.Homework.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            EditHomeworkWindow EditHomeworkWindow = new EditHomeworkWindow();
            EditHomeworkWindow.Show();
        }
    }
}