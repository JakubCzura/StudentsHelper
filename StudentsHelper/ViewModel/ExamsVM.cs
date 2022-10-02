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

namespace StudentsHelper.ViewModel
{
    public class ExamsVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to ExamsUserControl.xaml
        public ExamsVM()
        {
            AddExamCommand = new ShowAddExamCommand();
            DeleteExamCommand = new DeleteExamCommand(this);
            ShowEditExamCommand = new ShowEditExamCommand();
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
        }

        public static ExamsVM? Instance { get; set; }

        private ObservableCollection<Exam> exams = LoginStudent.GetExamsData();

        public ShowAddExamCommand AddExamCommand { get; set; }

        public DeleteExamCommand DeleteExamCommand { get; set; }

        public ShowEditExamCommand ShowEditExamCommand { get; set; }
        
        public EditExamWindow EditExamWindow { get; set; }
                             
        public ObservableCollection<Exam> Exams
        { 
            get { return exams; }
            set { exams = value; OnPropertyChanged(nameof(Exams)); }
        }

        private Exam selectedExam{ get; set; }
        public Exam SelectedExam
        {
            get { return selectedExam; }
            set { selectedExam = value; OnPropertyChanged(nameof(SelectedExam)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetWindowHidden()
        {
            if (ExamsUserControl.Instance != null)
            {
                ExamsUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (ExamsUserControl.Instance != null)
            {
                ExamsUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
