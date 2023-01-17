using StudentsHelper.DataBase;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveEditedExamCommand : ICommand
    {
        private EditExamVM EditExamVM { get; set; }

        public SaveEditedExamCommand(EditExamVM editExamVM)
        {
            EditExamVM = editExamVM;
        }

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
            if (DataUpdating.Update(EditExamVM.SelectedExam))
            {
                if (ExamsVM.Instance != null)
                {
                    ExamsVM.Instance.Exams = StudentLoggingIn.GetExamsData();
                    ExamsVM.Instance.SortExamsDateAscending();
                }
                MessageBox.Show("Zapisano pomyślnie", "edytowano egzamin");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować egzamin ponownie", "Błąd edytowania egzaminu");
            }
        }
    }
}