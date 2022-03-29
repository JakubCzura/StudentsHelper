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
    public class SaveTeacherCommand : ICommand
    {
        public SaveTeacherCommand(AddTeacherVM addTeacherVM)
        {
            AddTeacherVM = addTeacherVM;
        }

        AddTeacherVM AddTeacherVM { get; set; }

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
            if (SaveTeacher.Save(AddTeacherVM.Teacher))
            {
                MessageBox.Show("Zapisano pomyślnie", "Dodano wykładowcę");
            }
            else
            {
                MessageBox.Show("Spróbuj dodać wykładowcę ponownie", "Błąd dodania wykładowcy");
            }
        }
    }
}
