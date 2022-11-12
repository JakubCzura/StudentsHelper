using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System.Windows.Input;

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

        public ICommand EditUserProfileCommand { get; set; }

        public ICommand SaveEditedUserProfileCommand { get; set; }

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