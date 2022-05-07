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
    public class DeleteHomeworkCommand : ICommand
    {
        public DeleteHomeworkCommand(HomeworkVM homeworkVM)
        {
            HomeworkVM = homeworkVM;
        }

        HomeworkVM HomeworkVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (HomeworkVM.Instance?.Homework != null && HomeworkVM.Instance.Homework.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (SaveData.Delete(HomeworkVM.SelectedHomework))
            {
                if (HomeworkVM.Instance != null)
                {
                    HomeworkVM.Instance.Homework = LoginStudent.GetHomeworkData();
                }
                MessageBox.Show("Skasowano informację o zadaniu domowym", "Zapisano pomyślnie");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować informację o zadaniu domowym ponownie", "Błąd skasowania informacji o zadaniu domowym");
            }
        }
    }
}
