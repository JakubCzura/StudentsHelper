using StudentsHelper.DataBase;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveEditedNoteCommand : ICommand
    {
        public SaveEditedNoteCommand(EditNoteVM editNoteVM)
        {
            EditNoteVM = editNoteVM;
        }

        private EditNoteVM EditNoteVM { get; set; }

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
            if (DataUpdating.Update(EditNoteVM.SelectedNote))
            {
                if (NotesVM.Instance != null)
                {
                    NotesVM.Instance.Notes = ObjectsDataGetter.GetNotesData();
                }
                MessageBox.Show("Zapisano pomyślnie", "edytowano notatkę");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować notatkę ponownie", "Błąd edytowania notatki");
            }
        }
    }
}