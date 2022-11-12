using StudentsHelper.DataBase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class DeleteNoteCommand : ICommand
    {
        public DeleteNoteCommand(NotesVM notesVM)
        {
            NotesVM = notesVM;
        }

        private NotesVM NotesVM { get; set; }

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
            if (SaveData.Delete(NotesVM.SelectedNote))
            {
                if (NotesVM.Instance != null)
                {
                    NotesVM.Instance.Notes = LoginStudent.GetNotesData();
                }
                MessageBox.Show("Skasowano informację o notatce", "Zapisano pomyślnie");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować informację o notatce ponownie", "Błąd skasowania informacji o notatce");
            }
        }
    }
}