using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class AddTestCommand : ICommand
    {

        public AddTestCommand(TestVM testVM)
        {
            TestVM = testVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        TestVM TestVM { get; set; }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            AddTestWindow AddTestWindow = new AddTestWindow();
            AddTestWindow.Show();
        }
    }
}
