using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.UserControls;
using StudentsHelper.ViewModel.Commands;
using StudentsHelper.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class PasswordChangeVM : INotifyPropertyChanged, IVisibility
    {
        public PasswordChangeVM()
        {
            WindowsVisibility.HideSettings += SetHidden;
            Student = LoginStudent.GetStudentData();
            Instance = this;
            SaveNewPasswordCommand = new SaveNewPasswordCommand(this);
        }

        public static PasswordChangeVM? Instance { get; set; }
        
        public SaveNewPasswordCommand SaveNewPasswordCommand { get; set; }              

        private Student student { get; set; }
              
        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetHidden()
        {
            if (PasswordChangeUserControl.Instance != null)
            {
                PasswordChangeUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetVisible()
        {
            if (PasswordChangeUserControl.Instance != null)
            {
                PasswordChangeUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }         
    }
}
