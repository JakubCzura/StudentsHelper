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
    public class ExamsVM : INotifyPropertyChanged, IWindowVisibility
    {
        public static ExamsVM? Instance { get; set; }

        Teacher teacher = new Teacher();

        private ObservableCollection<Exam> exams = LoginStudent.GetExamsData();

        public AddExamCommand AddExamCommand { get; set; }

        public ExamsVM()
        {
            AddExamCommand = new AddExamCommand(this);
            Instance = this;
        }

        public void SetWindowHidden()
        {
            ExamsUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
        }

        public void SetWindowVisible()
        {
            ExamsUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
        }

        public string TeacherFullName
        {
            get { return teacher.ToString(); }
        }

        public Teacher Teacher
        {
            set 
            { 
                teacher = value; 
                OnPropertyChanged(nameof(Teacher)); 
            }        
        }
            
        public ObservableCollection<Exam> Exams
        { 
            get { return exams; }
            set 
            { 
                exams = value; 
                OnPropertyChanged(nameof(Exams));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
