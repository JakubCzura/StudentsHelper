using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.UserControls;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class UserProfileVM : BaseViewModel
    {
        public UserProfileVM()
        {
            EditUserProfileCommand = new EditUserProfileCommand(this);
            SaveEditedUserProfileCommand = new SaveEditedUserProfileCommand(this);
            Student = LoginStudent.GetStudentData();
            DegreeCourse = LoginStudent.GetDegreeCourseData();
            Instance = this;
        }
        public static UserProfileVM? Instance { get; set; }

        public EditUserProfileCommand EditUserProfileCommand { get; set; }

        public SaveEditedUserProfileCommand SaveEditedUserProfileCommand { get; set; }
        
       
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
    }
}
