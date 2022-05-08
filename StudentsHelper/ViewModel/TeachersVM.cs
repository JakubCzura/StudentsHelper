using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.UserControls;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class TeachersVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to TeachersUserControl.xaml
        public static TeachersVM? Instance { get; set; }

        private ObservableCollection<Teacher> teachers = LoginStudent.GetTeachersData();

        public AddTeacherCommand AddTeacherCommand { get; set; }

        public DeleteTeacherCommand DeleteTeacherCommand { get; set; }

        public TeachersVM()
        {
            AddTeacherCommand = new AddTeacherCommand(this);
            DeleteTeacherCommand = new DeleteTeacherCommand(this);
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
        }

        public ObservableCollection<Teacher> Teachers
        {
            get { return teachers; }
            set
            {
                teachers = value;
                OnPropertyChanged(nameof(teachers));
            }
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

        public void SetWindowHidden()
        {
            if (TeachersUserControl.Instance != null)
            {
                TeachersUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (TeachersUserControl.Instance != null)
            {
                TeachersUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
