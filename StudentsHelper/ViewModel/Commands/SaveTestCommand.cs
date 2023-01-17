using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveTestCommand : ICommand
    {
        public SaveTestCommand(AddTestVM addTestVM)
        {
            AddTestVM = addTestVM;
        }

        private AddTestVM AddTestVM { get; set; }

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
                if (TestDataValidator.ValidateTestData(AddTestVM.Test))
                {
                    if (DataSaving.Save(AddTestVM.Test))
                    {
                        if (TestsVM.Instance != null)
                        {
                            TestsVM.Instance.Tests = ObjectsDataGetter.GetTestsData();
                            TestsVM.Instance.SortTestsDateAscending();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano kolokwium");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać kolokwium ponownie", "Błąd dodania kolokwium");
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