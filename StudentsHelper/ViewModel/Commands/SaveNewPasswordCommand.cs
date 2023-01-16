using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.View.UserControls;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class SaveNewPasswordCommand : ICommand
    {
        public SaveNewPasswordCommand(PasswordChangeVM passwordChangeVM)
        {
            PasswordChangeVM = passwordChangeVM;
        }

        private PasswordChangeVM PasswordChangeVM { get; set; }

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

        private void ChangePassword()
        {
            try
            {
                if (PasswordChangeUserControl.Instance?.OldPasswordBox.Password.Length > 1
                    && PasswordChangeUserControl.Instance?.NewPasswordBox.Password.Length > 1
                    && PasswordChangeUserControl.Instance?.RepeatedPasswordBox.Password.Length > 1)
                {
                    //if (PasswordChangeVM.Student.Password == DataBase.Hasher.VerifyPassword(PasswordChangeUserControl.Instance?.OldPasswordBox.Password)
                    if (Hasher.VerifyPassword(PasswordChangeUserControl.Instance?.OldPasswordBox.Password, PasswordChangeVM.Student.Password))
                    {
                        if (PasswordChangeUserControl.Instance.NewPasswordBox.Password == PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password)
                        {
                            PasswordChangeVM.Student.Password = Hasher.HashPassword(PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password);
                            if (StudentDataValidator.ValidateStudentData(PasswordChangeVM.Student))
                            {
                                DataUpdating.Update(PasswordChangeVM.Student);
                                MessageBox.Show("Zapisano pomyślnie", "Edytowano informacje");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Powtórzone hasła są różne", "Nie zapisano hasła");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Podane stare hasło się nie zgadza", "Nie zapisano hasła");
                    }
                }
                else
                {
                    MessageBox.Show("Długość podanego hasła jest za mała", "Nie zapisano hasła");
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

        private static void SetPasswordEmpty()
        {
            PasswordChangeUserControl.Instance.OldPasswordBox.Password = String.Empty;
            PasswordChangeUserControl.Instance.NewPasswordBox.Password = String.Empty;
            PasswordChangeUserControl.Instance.RepeatedPasswordBox.Password = String.Empty;
        }
    }
}