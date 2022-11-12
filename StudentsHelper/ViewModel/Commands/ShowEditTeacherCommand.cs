using StudentsHelper.View.Windows;
using System;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowEditTeacherCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (TeachersVM.Instance?.Teachers != null && TeachersVM.Instance.Teachers.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            EditTeacherWindow EditTeacherWindow = new EditTeacherWindow();
            EditTeacherWindow.Show();
        }
    }
}