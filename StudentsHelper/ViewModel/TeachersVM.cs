using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System.Collections.ObjectModel;

namespace StudentsHelper.ViewModel
{
    public class TeachersVM : BaseViewModel
    {
        //This class refers to TeachersUserControl.xaml
        public TeachersVM()
        {
            AddTeacherCommand = new ShowAddTeacherCommand();
            DeleteTeacherCommand = new DeleteTeacherCommand(this);
            ShowEditTeacherCommand = new ShowEditTeacherCommand();
            Instance = this;
        }

        public static TeachersVM? Instance { get; set; }

        private ObservableCollection<Teacher> teachers = LoginStudent.GetTeachersData();

        public ShowAddTeacherCommand AddTeacherCommand { get; set; }

        public DeleteTeacherCommand DeleteTeacherCommand { get; set; }
        
        public ShowEditTeacherCommand ShowEditTeacherCommand { get; set; }
       
        public EditTeacherWindow EditTeacherWindow { get; set; }
          
        public ObservableCollection<Teacher> Teachers
        {
            get { return teachers; }
            set { teachers = value; OnPropertyChanged(nameof(teachers)); }
        }

        private Teacher selectedTeacher{ get; set; }
        public Teacher SelectedTeacher
        {
            get
            {
                return selectedTeacher;
            }
            set
            {
                selectedTeacher= value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }      
    }
}
