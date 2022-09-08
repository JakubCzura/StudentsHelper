using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.View;
using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class AcceptRegisterCommand : ICommand
    {
        public AcceptRegisterCommand(RegisterWindowVM registerWindowVM)
        {
            RegisterWindowVM = registerWindowVM;
        }

        RegisterWindowVM RegisterWindowVM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        private bool ValidateData()
        {
            if (StudentDataValidator.ValidateName(RegisterWindowVM.Name) &&
                StudentDataValidator.ValidateSecondName(RegisterWindowVM.SecondName) &&
                StudentDataValidator.ValidateAge(RegisterWindowVM.Age) &&
                DegreeCourseDataValidator.ValidateCourse(RegisterWindowVM.Course) &&
                DegreeCourseDataValidator.ValidateSpeciality(RegisterWindowVM.Speciality) &&
                DegreeCourseDataValidator.ValidateSemester(RegisterWindowVM.Semestr) &&
                DegreeCourseDataValidator.ValidateFaculty(RegisterWindowVM.Faculty)
                )
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            try
            {
                if (RegisterWindow.Instance != null)
                {
                    RegisterWindowVM.Password = RegisterWindow.Instance.PasswordBox.Password;

                    if ((StudentDataValidator.ValidatePassword(RegisterWindowVM.Password) &&
                        StudentDataValidator.ValidateLogin(RegisterWindowVM.Login)))
                    {
                        ValidateData();
                        if (RegisterStudent.Register(RegisterWindowVM) == true)
                        {
                            LoginWindow LoginWindow = new LoginWindow();
                            LoginWindow.Show();
                            RegisterWindow.Instance.Close();
                            MessageBox.Show("Rejestracja przebiegła pomyślnie\nMożesz się zalogować!", "Zarejestrowano");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
