using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;

namespace StudentsHelper.ViewModel
{
    public class PasswordChangeVM : BaseViewModel
    {
        public PasswordChangeVM()
        {
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
    }
}
