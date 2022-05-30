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
    public class EditExamCommand : ICommand
    {
        public EditExamCommand(ExamsVM examsVM)
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
            ExamsVM.EditExamWindow = new EditExamWindow();
            //EditExamVM.Instance.SelectedExam = ExamsVM.SelectedExam;
            //MessageBox.Show(EditExamVM.Instance.SelectedExam.Name);
            ExamsVM.EditExamWindow.Show();
        }
    }
}
