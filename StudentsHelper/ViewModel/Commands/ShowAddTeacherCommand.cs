using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowAddTeacherCommand : ICommand
    {
        public ShowAddTeacherCommand(TeachersVM teachersVM)
        {
            TeachersVM = teachersVM;
        }
            
        TeachersVM TeachersVM{ get; set; }

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
            AddTeacherWindow AddTeacherWindow = new AddTeacherWindow();
            AddTeacherWindow.Show();
        }
    }
}
