using StudentsHelper.DataBase;
using System;
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

        private EditTestVM EditTestVM { get; set; }

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
            if (DataUpdating.Update(EditTestVM.SelectedTest))
            {
                if (TestsVM.Instance != null)
                {
                    TestsVM.Instance.Tests = ObjectsDataGetter.GetTestsData();
                }
                MessageBox.Show("Zapisano pomyślnie", "edytowano kolokwium");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować kolokwium ponownie", "Błąd edytowania kolokwium");
            }
        }
    }
}