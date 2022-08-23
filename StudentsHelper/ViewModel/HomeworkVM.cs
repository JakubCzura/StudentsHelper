using SQLite;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.UserControls;
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

namespace StudentsHelper.ViewModel
{
    public class HomeworkVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to HomeworkUserControl.xaml

        public HomeworkVM()
        {
            AddHomeworkCommand = new ShowAddHomeworkCommand();
            DeleteHomeworkCommand = new DeleteHomeworkCommand(this);
            EditHomeworkCommand = new ShowEditHomeworkCommand(this);
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
        }

        public static HomeworkVM? Instance { get; set; }

        private ObservableCollection<Homework> homework = LoginStudent.GetHomeworkData();

        public ShowAddHomeworkCommand AddHomeworkCommand { get; set; }

        public DeleteHomeworkCommand DeleteHomeworkCommand { get; set; }

        public ShowEditHomeworkCommand EditHomeworkCommand { get; set; }

        public EditHomeworkWindow EditHomeworkWindow { get; set; }

        public ObservableCollection<Homework> Homework
        {
            get { return homework; }
            set { homework = value; OnPropertyChanged(nameof(Homework)); }
        }

        private Homework selectedHomework{ get; set; }
        public Homework SelectedHomework
        {
            get { return selectedHomework; }
            set { selectedHomework = value; OnPropertyChanged(nameof(SelectedHomework)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetWindowHidden()
        {
            if (HomeworkUserControl.Instance != null)
            {
                HomeworkUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (HomeworkUserControl.Instance != null)
            {
                HomeworkUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}