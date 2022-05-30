using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class EditNoteCommand : ICommand
    {
        public EditNoteCommand(NotesVM notesVM)
        {
            NotesVM = notesVM;
        }

        NotesVM NotesVM { get; set; }

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
            NotesVM.EditNoteWindow = new EditNoteWindow();
            NotesVM.EditNoteWindow.Show();
        }
    }
}
