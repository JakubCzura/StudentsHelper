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
    public class SaveEditedTestCommand : ICommand
    {
        public SaveEditedTestCommand(EditTestVM editTestVM)
        {
            EditTestVM = editTestVM;
        }

        EditTestVM EditTestVM { get; set; }

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
            if (SaveData.Update(EditTestVM.SelectedTest))
            {
                if (TestsVM.Instance != null)
                {
                    TestsVM.Instance.Tests = LoginStudent.GetTestsData();
                    TestsVM.Instance.SortTestsDateAscending();
                }
                MessageBox.Show("Zapisano pomyślnie", "edytowano test");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować test ponownie", "Błąd edytowania testu");
            }
        }
    }
}
