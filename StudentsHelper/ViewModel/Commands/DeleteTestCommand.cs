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
    public class DeleteTestCommand : ICommand
    {
        public DeleteTestCommand(TestVM testVM)
        {
            TestVM = testVM;
        }

        TestVM TestVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (TestVM.Instance?.Tests != null && TestVM.Instance.Tests.Any() == true)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (SaveData.Delete(TestVM.SelectedTest))
            {
                if (TestVM.Instance != null)
                {
                    TestVM.Instance.Tests = LoginStudent.GetTestsData();
                }
                MessageBox.Show("Skasowano informację o teście", "Zapisano pomyślnie");
            }
            else
            {
                MessageBox.Show("Spróbuj skasować informację o teście ponownie", "Błąd skasowania informacji o teście");
            }
        }
    }
}