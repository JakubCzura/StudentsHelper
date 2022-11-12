using StudentsHelper.View.Windows;
using System;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class BackToLoginCommand : ICommand
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
            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Show();
            RegisterWindow.Instance?.Close();
        }
    }
}