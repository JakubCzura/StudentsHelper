using StudentsHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StudentsHelper.DataValidators;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveTestCommand : ICommand
    {
        public SaveTestCommand(AddTestVM addTestVM)
        {
            AddTestVM = addTestVM;
        }

        AddTestVM AddTestVM { get; set; }

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
                    if (SaveData.Save(AddTestVM.Test))
                    {
                        if (TestsVM.Instance != null)
                        {
                            TestsVM.Instance.Tests = LoginStudent.GetTestsData();
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
