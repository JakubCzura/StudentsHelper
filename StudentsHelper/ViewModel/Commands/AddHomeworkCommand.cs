using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class AddHomeworkCommand : ICommand
    { 
        public AddHomeworkCommand(HomeworkVM homeworkVM)
        {
            HomeworkVM = homeworkVM;
        }

        HomeworkVM HomeworkVM { get; set; }

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
            AddHomeworkWindow AddHomeworkVM = new AddHomeworkWindow();
            AddHomeworkVM.Show();
        }
    }
}
