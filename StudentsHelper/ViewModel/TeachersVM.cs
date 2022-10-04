using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.UserControls;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using StudentsHelper.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StudentsHelper.ViewModel
{
    public class TeachersVM : INotifyPropertyChanged, IVisibility
    {
        //This class refers to TeachersUserControl.xaml
        public TeachersVM()
        {
            AddTeacherCommand = new ShowAddTeacherCommand();
            DeleteTeacherCommand = new DeleteTeacherCommand(this);
            ShowEditTeacherCommand = new ShowEditTeacherCommand();
            Instance = this;
            WindowsVisibility.HideMainWindowDuties += SetHidden;
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

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetHidden()
        {
            if (TeachersUserControl.Instance != null)
            {
                TeachersUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetVisible()
        {
            if (TeachersUserControl.Instance != null)
            {
                TeachersUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
