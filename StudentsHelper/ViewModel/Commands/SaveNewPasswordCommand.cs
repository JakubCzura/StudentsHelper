using StudentsHelper.DataBase;
using StudentsHelper.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveNewPasswordCommand : ICommand
    {
        public SaveNewPasswordCommand(PasswordChangeVM passwordChangeVM)
        {
            PasswordChangeVM = passwordChangeVM;
        }

        PasswordChangeVM PasswordChangeVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(PasswordChangeUserControl.Instance?.OldPasswordBox.Password) == false
                && string.IsNullOrWhiteSpace(PasswordChangeUserControl.Instance?.NewPasswordBox.Password) == false
                && string.IsNullOrWhiteSpace(PasswordChangeUserControl.Instance?.RepeatedPasswordBox.Password) == false)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            ChangePassword();
        }

        void ChangePassword()
        {
            try
            {
                if (PasswordChangeUserControl.Instance?.OldPasswordBox.Password.Length > 1
                    && PasswordChangeUserControl.Instance.NewPasswordBox.Password.Length > 1
                    && PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password.Length > 1)
                {
                    if (PasswordChangeVM.Student.Password == PasswordChangeUserControl.Instance?.OldPasswordBox.Password
                    && PasswordChangeUserControl.Instance.NewPasswordBox.Password == PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password)
                    {
                        PasswordChangeVM.Student.Password = PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password;
                        SaveData.Update(PasswordChangeVM.Student);
                        MessageBox.Show("Zapisano pomyślnie", "Edytowano informacje");
                    }
                    else
                    {
                        MessageBox.Show("Hasło nie mogło zostać zmienione, prosimy sprobówać ponownie", "Nie zapisano hasła");
                    }
                }
                else
                {
                    MessageBox.Show("Hasło nie mogło zostać zmienione, prosimy sprobówać ponownie", "Nie zapisano hasła");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nHasło nie mogło zostać zmienione, prosimy sprobówać ponownie", "Nie zapisano hasła");
            }
            finally
            {
                SetPasswordEmpty();
            }
        }

        private void SetPasswordEmpty()
        {
            PasswordChangeUserControl.Instance.OldPasswordBox.Password = String.Empty;
            PasswordChangeUserControl.Instance.NewPasswordBox.Password = String.Empty;
            PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password = String.Empty;
        }
    }
}
