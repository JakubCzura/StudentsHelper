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
    public class DeleteNoteCommand : ICommand
    {
        public DeleteNoteCommand(NotesVM notesVM)
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
            return true;
        }

        public void Execute(object? parameter)
        {
            if (SaveData.Delete(NotesVM.SelectedNote))
            {
                if (NotesVM.Instance != null)
                {
                    NotesVM.Instance.Notes = LoginStudent.GetNotesData();
                }
                MessageBox.Show("Zapisano pomyślnie", "Skasowano notatkę");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować notatkę ponownie", "Błąd skasowania notatki");
            }
        }
    }
}
