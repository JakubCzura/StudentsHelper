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
    public class ShowEditExamCommand : ICommand
    {
        public ShowEditExamCommand(ExamsVM examsVM)
        {
            ExamsVM = examsVM;
        }

        ExamsVM ExamsVM { get; set; }

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
            EditExamWindow EditExamWindow  = new EditExamWindow();
            EditExamWindow.Show();
        }
    }
}
