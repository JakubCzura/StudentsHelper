using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveEditedTeacherCommand : ICommand
    {
        public SaveEditedTeacherCommand(EditTeacherVM editTeacherVM)
        {
            EditTeacherVM = editTeacherVM;
        }

        private EditTeacherVM EditTeacherVM { get; set; }

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
                if (TeacherDataValidator.ValidateTeacherData(EditTeacherVM.SelectedTeacher))
                {
                    if (DataUpdating.Update(EditTeacherVM.SelectedTeacher))
                    {
                        if (TeachersVM.Instance != null)
                        {
                            TeachersVM.Instance.Teachers = StudentLoggingIn.GetTeachersData();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "edytowano informacje o wykładowcy");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj edytować informacje o wykładowcy ponownie", "Błąd edytowania informacji o wykładowcy");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}