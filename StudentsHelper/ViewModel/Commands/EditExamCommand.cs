using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class EditExamCommand : ICommand
    {
        //public EditExamCommand(EditExamVM editExamVM)
        //{
        //    EditExamVM = editExamVM;
        //}

        EditExamVM EditExamVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (ExamsVM.Instance?.Exams != null && ExamsVM.Instance.Exams.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            EditExamWindow EditExamWindow = new EditExamWindow();
            EditExamWindow.Show();
        }
    }
}
