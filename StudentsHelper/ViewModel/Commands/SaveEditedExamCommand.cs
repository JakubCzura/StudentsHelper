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
    public class SaveEditedExamCommand : ICommand
    {
        EditExamVM EditExamVM { get; set; }

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
            if (SaveData.Update(EditExamVM.SelectedExam))
            {
                if (ExamsVM.Instance != null)
                {
                    ExamsVM.Instance.Exams = LoginStudent.GetExamsData();
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
