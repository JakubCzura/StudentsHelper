﻿using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    internal class AddExamCommand : ICommand
    {
        public AddExamCommand(ExamsVM examsVM)
        {
            ExamsVM = examsVM;
        }

        ExamsVM ExamsVM { get; set; }

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
            AddExamWindow AddExamWindow= new AddExamWindow();
            AddExamWindow.Show();
        }
    }
}