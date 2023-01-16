using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveNoteCommand : ICommand
    {
        public SaveNoteCommand(AddNoteVM addNoteVM)
        {
            AddNoteVM = addNoteVM;
        }

        private AddNoteVM AddNoteVM { get; set; }

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
            try
            {
                if (NoteDataValidator.ValidateNoteData(AddNoteVM.Note))
                {
                    if (DataSaving.Save(AddNoteVM.Note))
                    {
                        if (NotesVM.Instance != null)
                        {
                            NotesVM.Instance.Notes = LoginStudent.GetNotesData();
                            NotesVM.Instance.SortNotesDateAscending();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano notatkę");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać notatkę ponownie", "Błąd dodania notatki");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }
    }
}