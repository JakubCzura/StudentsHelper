﻿using StudentsHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        EditTeacherVM EditTeacherVM { get; set; }

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
            if (SaveData.Update(EditTeacherVM.SelectedTeacher))
            {
                if (TeachersVM.Instance != null)
                {
                    TeachersVM.Instance.Teachers = LoginStudent.GetTeachersData();
                }
                MessageBox.Show("Zapisano pomyślnie", "edytowano informacje o nauczycielu");
            }
            else
            {
                MessageBox.Show("Spróbuj edytować informacje o nauczycielu ponownie", "Błąd edytowania informacji o nauczycielu");
            }
        }
    }
}