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
    public class SaveTestCommand : ICommand
    {
        public SaveTestCommand(AddTestVM addTestVM)
        {
            AddTestVM = addTestVM;
        }

        AddTestVM AddTestVM { get; set; }

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
            if (SaveTest.Save(AddTestVM.Test))
            {
                MessageBox.Show("Zapisano pomyślnie", "Dodano kolokwium");
            }
            else
            {
                MessageBox.Show("Spróbuj dodać kolokwium ponownie", "Błąd dodania kolokwium");
            }
        }
    }
}