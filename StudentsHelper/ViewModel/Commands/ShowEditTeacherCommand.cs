using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowEditTeacherCommand : ICommand
    {
        public ShowEditTeacherCommand(TeachersVM teachersVM)
        {
            TeachersVM = teachersVM;
        }

        TeachersVM TeachersVM { get; set; }

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
