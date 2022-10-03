using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowAuthorsWindowCommand : ICommand
    {
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
            AuthorsWindow AuthorsWindow = new AuthorsWindow();
            AuthorsWindow.Show();
        }
    }
}
