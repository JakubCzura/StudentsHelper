using StudentsHelper.DataBase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class DeleteTeacherCommand : ICommand
    {
        public DeleteTeacherCommand(TeachersVM teachersVM)
        {
            TeachersVM = teachersVM;
        }

        private TeachersVM TeachersVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (TeachersVM.Instance?.Teachers != null && TeachersVM.Instance.Teachers.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (DataDeletion.Delete(TeachersVM.SelectedTeacher))
            {
                if (TeachersVM.Instance != null)
                {
                    TeachersVM.Instance.Teachers = LoginStudent.GetTeachersData();
                }
                MessageBox.Show("Skasowano informację o nauczycielu", "Zapisano pomyślnie");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować informację o nauczycielu ponownie", "Błąd skasowania informacji o nauczycielu");
            }
        }
    }
}