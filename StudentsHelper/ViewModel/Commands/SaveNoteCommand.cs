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
    public class SaveNoteCommand : ICommand
    {
        public SaveNoteCommand(AddNoteVM addNoteVM)
        {
            AddNoteVM = addNoteVM;
        }

        AddNoteVM AddNoteVM { get; set; }

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
            if (SaveNote.Save(AddNoteVM.Note))
            {
                MessageBox.Show("Zapisano pomyślnie", "Dodano kolokwium");
            }
            else
            {
                MessageBox.Show("Spróbuj dodać kolokwium ponownie", "Błąd dodania kolokwium");
            }
        }
    }
}
