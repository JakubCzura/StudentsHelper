using StudentsHelper.View.Windows;
using System;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowEditNoteCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (NotesVM.Instance?.Notes != null && NotesVM.Instance.Notes.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            EditNoteWindow EditNoteWindow = new EditNoteWindow();
            EditNoteWindow.Show();
        }
    }
}