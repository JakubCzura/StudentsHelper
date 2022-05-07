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
    public class DeleteExamCommand : ICommand
    {
        public DeleteExamCommand(ExamsVM examsVM)
        {
            ExamsVM = examsVM;
        }

        ExamsVM ExamsVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (ExamsVM.Instance?.Exams != null && ExamsVM.Instance.Exams.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (SaveData.Delete(ExamsVM.SelectedExam))
            {
                if (ExamsVM.Instance != null)
                {
                    ExamsVM.Instance.Exams = LoginStudent.GetExamsData();
                }
                MessageBox.Show("Skasowano informację o egzaminie", "Zapisano pomyślnie");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować informację o egzaminie ponownie", "Błąd skasowania informacji o egzaminie");
            }
        }
    }
}
