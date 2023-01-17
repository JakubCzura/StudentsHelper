using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class TeachersVM : BaseViewModel
    {
        //This class refers to TeachersUserControl.xaml
        public TeachersVM()
        {
            AddTeacherCommand = new ShowWindowCommand();
            DeleteTeacherCommand = new DeleteTeacherCommand(this);
            ShowEditTeacherCommand = new ShowEditTeacherCommand();
            Instance = this;
        }

        public static TeachersVM? Instance { get; set; }

        private ObservableCollection<Teacher> teachers = StudentLoggingIn.GetTeachersData();

        public ObservableCollection<Teacher> Teachers
        {
            get { return teachers; }
            set { teachers = value; OnPropertyChanged(nameof(teachers)); }
        }

        public ICommand AddTeacherCommand { get; set; }

        public ICommand DeleteTeacherCommand { get; set; }

        public ICommand ShowEditTeacherCommand { get; set; }

        private Teacher selectedTeacher { get; set; }

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set { selectedTeacher = value; OnPropertyChanged(nameof(SelectedTeacher)); }
        }
    }
}