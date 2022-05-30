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
    public class EditTestCommand : ICommand
    {
        public EditTestCommand(TestVM testVM)
        {
            TestVM = testVM;
        }

        TestVM TestVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (TestVM.Instance?.Tests != null && TestVM.Instance.Tests.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            TestVM.EditTestWindow = new EditTestWindow();
            TestVM.EditTestWindow.Show();
        }
    }
}
