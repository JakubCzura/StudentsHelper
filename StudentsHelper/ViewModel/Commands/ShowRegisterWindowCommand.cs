using StudentsHelper.View.Windows;
using System;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowRegisterWindowCommand : ICommand
    {
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
            RegisterWindow RegisterWindow = new RegisterWindow();
            RegisterWindow.Show();
            LoginWindow.Instance?.Close();
        }
    }
}