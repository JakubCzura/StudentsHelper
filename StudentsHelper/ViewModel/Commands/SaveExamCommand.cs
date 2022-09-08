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
    public class SaveExamCommand : ICommand
    {
        public SaveExamCommand(AddExamVM addExamVM)
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
            try
            {
                if (ExamDataValidator.ValidateExamData(AddExamVM.Exam))
                {
                    if (SaveData.Save(AddExamVM.Exam))
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
            catch(Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }
    }
}
