using StudentsHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        EditNoteVM EditNoteVM { get; set; }

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
            if (SaveData.Update(EditNoteVM.SelectedNote))
            {
                if (NotesVM.Instance != null)
                {
                    NotesVM.Instance.Notes = LoginStudent.GetNotesData();
                    NotesVM.Instance.SortNotesDateAscending();
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
