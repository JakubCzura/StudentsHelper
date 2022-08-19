using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.UserControls;
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
    public class UserProfileVM : INotifyPropertyChanged, IWindowVisibility
    {
        public UserProfileVM()
        {
            EditUserProfileCommand = new EditUserProfileCommand(this);
            SaveEditedUserProfileCommand = new SaveEditedUserProfileCommand(this);
            WindowsVisibility.HideWindow += SetWindowHidden;
            Student = LoginStudent.GetStudentData();
            DegreeCourse = LoginStudent.GetDegreeCourseData();
            Instance = this;
        }
        public static UserProfileVM? Instance { get; set; }

        public EditUserProfileCommand EditUserProfileCommand { get; set; }

        public SaveEditedUserProfileCommand SaveEditedUserProfileCommand { get; set; }
        
        public event PropertyChangedEventHandler? PropertyChanged;
       
        private DegreeCourse degreeCourse { get; set; }

        public DegreeCourse DegreeCourse
        {
            get { return degreeCourse; }
            set { degreeCourse = value; OnPropertyChanged(nameof(DegreeCourse)); }
        }

        private Student student { get; set; }

        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        public void SetWindowHidden()
        {
            if (UserProfileUserControl.Instance != null)
            {
                UserProfileUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (UserProfileUserControl.Instance != null)
            {
                UserProfileUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
