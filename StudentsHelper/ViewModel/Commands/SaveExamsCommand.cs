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
    public class SaveExamsCommand : ICommand
    {
        public SaveExamsCommand(AddExamVM addExamVM)
        {
            AddExamVM = addExamVM;
        }

        AddExamVM AddExamVM { get; set; }

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
            if(SaveData.Save(AddExamVM.Exam))
            {
                if (ExamsVM.Instance != null)
                {
                    ExamsVM.Instance.Exams = LoginStudent.GetExamsData();
                }
                MessageBox.Show("Zapisano pomyślnie", "Dodano egzamin");
            }
            else
            {
                MessageBox.Show("Spróbuj dodać egzamin ponownie", "Błąd dodania egzaminu");
            }
        }
    }
}
