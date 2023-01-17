using CommunityToolkit.Mvvm.Input;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class TeachersVM : BaseViewModel
    {
        //This class refers to TeachersUserControl.xaml
        public TeachersVM()
        {
            AddTeacherCommand = new RelayCommand(ShowAddTeacherWindow);
            DeleteTeacherCommand = new RelayCommand(DeleteTeacher);
            ShowEditTeacherCommand = new RelayCommand(ShowEditTeacherWindow);
            Instance = this;
            Teachers = ObjectsDataGetter.GetTeachersData();
        }

        private void DeleteTeacher()
        {
            if (Teachers != null && Teachers.Any() == true)
            {
                if (DataDeletion.Delete(SelectedTeacher))
                {
                    Teachers = ObjectsDataGetter.GetTeachersData();
                    MessageBox.Show("Skasowano informację o nauczycielu", "Zapisano pomyślnie");
                }
                else
                {
                    MessageBox.Show("Spróbuj skasować informację o nauczycielu ponownie", "Błąd skasowania informacji o nauczycielu");
                }
            }
        }

        private void ShowEditTeacherWindow()
        {
            if (Teachers != null && Teachers.Any() == true)
            {
                EditTeacherWindow EditTeacherWindow = new();
                EditTeacherWindow.Show();
            }
        }

        private void ShowAddTeacherWindow()
        {
            AddTeacherWindow AddTeacherWindow = new();
            AddTeacherWindow.Show();
        }

        public static TeachersVM? Instance { get; set; }

        private ObservableCollection<Teacher> teachers;

        public ObservableCollection<Teacher> Teachers
        {
            get { return teachers; }
            set { teachers = value; OnPropertyChanged(nameof(teachers)); }
        }

        public ICommand AddTeacherCommand { get; private set; }

        public ICommand DeleteTeacherCommand { get; private set; }

        public ICommand ShowEditTeacherCommand { get; private set; }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set { selectedTeacher = value; OnPropertyChanged(nameof(SelectedTeacher)); }
        }
    }
}