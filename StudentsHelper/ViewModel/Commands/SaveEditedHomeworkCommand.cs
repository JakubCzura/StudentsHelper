using StudentsHelper.DataBase;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveEditedHomeworkCommand : ICommand
    {
        public SaveEditedHomeworkCommand(EditHomeworkVM editHomeworkVM)
        {
            EditHomeworkVM = editHomeworkVM;
        }

        private EditHomeworkVM EditHomeworkVM { get; set; }

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
            if (SaveData.Update(EditHomeworkVM.SelectedHomework))
            {
                if (HomeworkVM.Instance != null)
                {
                    HomeworkVM.Instance.Homework = LoginStudent.GetHomeworkData();
                    HomeworkVM.Instance.SortHomeworkDateAscending();
                }
                MessageBox.Show("Zapisano pomyślnie", "edytowano zadanie domowe");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować zadanie domowe ponownie", "Błąd edytowania zadania domowego");
            }
        }
    }
}