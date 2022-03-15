using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    internal class CloseWindowCommand : ICommand
    {
        public CloseWindowCommand(AddExamVM addExamVM /*AddExamWindow addExamWindow*/)
        {
            AddExamVM = addExamVM;
            //AddExamWindow = addExamWindow;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        AddExamVM AddExamVM { get; set; }
        //AddExamWindow AddExamWindow { get; set; }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           //AddExamWindow.Close();
        }
    }
}
