using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveTeacherCommand : ICommand
    {
        public SaveTeacherCommand(AddTeacherVM addTeacherVM)
        {
            AddTeacherVM = addTeacherVM;
        }

        private AddTeacherVM AddTeacherVM { get; set; }

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
                if (TeacherDataValidator.ValidateTeacherData(AddTeacherVM.Teacher))
                {
                    if (DataSaving.Save(AddTeacherVM.Teacher))
                    {
                        if (TeachersVM.Instance != null)
                        {
                            TeachersVM.Instance.Teachers = LoginStudent.GetTeachersData();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano wykładowcę");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać wykładowcę ponownie", "Błąd dodania wykładowcy");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }
    }
}