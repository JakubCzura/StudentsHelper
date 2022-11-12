using StudentsHelper.View.Windows;
using System;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowEditTestCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (TestsVM.Instance?.Tests != null && TestsVM.Instance.Tests.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            EditTestWindow EditTestWindow = new EditTestWindow();
            EditTestWindow.Show();
        }
    }
}