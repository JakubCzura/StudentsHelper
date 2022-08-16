using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.UserControls;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class PasswordChangeVM : INotifyPropertyChanged, IWindowVisibility
    {
        public static PasswordChangeVM? Instance { get; set; }
        
        public SaveNewPasswordCommand SaveNewPasswordCommand { get; set; }
        
        public PasswordChangeVM()
        {
            WindowsVisibility.HideSettings += SetWindowHidden;
            Student = LoginStudent.GetStudentData();
            Instance = this;
            SaveNewPasswordCommand = new SaveNewPasswordCommand(this);
        }

        private Student student { get; set; }

        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        public void SetWindowHidden()
        {
            if (PasswordChangeUserControl.Instance != null)
            {
                PasswordChangeUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (PasswordChangeUserControl.Instance != null)
            {
                PasswordChangeUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
