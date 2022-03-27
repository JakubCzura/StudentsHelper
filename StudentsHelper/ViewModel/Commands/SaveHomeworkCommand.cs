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
    public class SaveHomeworkCommand : ICommand
    {
        public SaveHomeworkCommand(AddHomeworkVM addHomeworkVM)
        {
            AddHomeworkVM = addHomeworkVM;
        }

        AddHomeworkVM AddHomeworkVM { get; set; }

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
            if (SaveHomework.Save(AddHomeworkVM.Homework))
            {
                MessageBox.Show("Zapisano pomyślnie", "Dodano pracę domową");
            }
            else
            {
                MessageBox.Show("Spróbuj dodać pracę domową ponownie", "Błąd dodania pracy domowej");
            }
        }
    }
}
