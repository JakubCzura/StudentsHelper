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
    public class SaveHomeworkCommand : ICommand
    {
        public SaveHomeworkCommand(AddHomeworkVM addHomeworkVM)
        {
            AddHomeworkVM = addHomeworkVM;
        }

        AddHomeworkVM AddHomeworkVM { get; set; }

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
            if (SaveData.Save(AddHomeworkVM.Homework))
            {
                if (HomeworkVM.Instance != null)
                {
                    HomeworkVM.Instance.Homework = LoginStudent.GetHomeworkData();
                    HomeworkVM.Instance.SortHomeworkDateAscending();
                }
                MessageBox.Show("Zapisano pomyślnie", "Dodano zadanie domowe");
            }
            else
            {
                MessageBox.Show("Spróbuj dodać pracę domową ponownie", "Błąd dodania pracy domowej");
            }
        }
    }
}
