using StudentsHelper.DataBase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class DeleteTestCommand : ICommand
    {
        public DeleteTestCommand(TestsVM testVM)
        {
            TestVM = testVM;
        }

        private TestsVM TestVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (TestVM?.Tests != null && TestVM?.Tests.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (SaveData.Delete(TestVM.SelectedTest))
            {
                if (TestsVM.Instance != null)
                {
                    TestVM.Tests = LoginStudent.GetTestsData();
                }
                MessageBox.Show("Skasowano informację o teście", "Zapisano pomyślnie");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować informację o teście ponownie", "Błąd skasowania informacji o teście");
            }
        }
    }
}