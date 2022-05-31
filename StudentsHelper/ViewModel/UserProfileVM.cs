using StudentsHelper.Model;
using StudentsHelper.UserControls;
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
        public static UserProfileVM Instance { get; set; }

        public UserProfileVM()
        {
            WindowsVisibility.HideWindow += SetWindowHidden;
            Instance = this;
        }

        //public string Name
        //{
        //    get { return Student.Name; }
        //    set { Student.Name = value; OnPropertyChanged(Name); }
        //}

        //public string SecondName
        //{
        //    get { return Student.SecondName; }
        //    set { Student.SecondName = value; }
        //}

        //public int Age
        //{
        //    get { return age; }
        //    set { age = value; }
        //}

        //public string Login
        //{
        //    get { return login; }
        //    set { login = value; }
        //}

        //public string Password
        //{
        //    get { return password; }
        //    set { password = value; }
        //}

        //public override string ToString()
        //{
        //    return Name + " " + Id + " " + SecondName + " " + " " + Age;
        //}


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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
