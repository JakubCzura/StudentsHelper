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
using System.Windows;

namespace StudentsHelper.ViewModel
{
    public class WelcomeScreenVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to WelcomeScreenUserControl.xaml
        public WelcomeScreenVM()
        {
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
            SelectedDaysToDeadline = 5;
            Tests = LoginStudent.GetTestsData();
            Homework = LoginStudent.GetHomeworkData();
            Exams = LoginStudent.GetExamsData();
            GetDutiesBeforeDeadline(SelectedDaysToDeadline);
        }


        public static WelcomeScreenVM? Instance { get; set; }

        private Student student = LoginStudent.GetStudentData();

        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        private readonly List<int> daysToDeadline = new List<int>() { 5, 10, 15 };
        public List<int> DaysToDeadline
        {
            get { return daysToDeadline; }
        }

        private int selectedDaysToDeadline = 5;

        public int SelectedDaysToDeadline
        {
            get { return selectedDaysToDeadline; }
            set { selectedDaysToDeadline = value; OnPropertyChanged(nameof(SelectedDaysToDeadline)); GetDutiesBeforeDeadline(SelectedDaysToDeadline); }
        }

        private ObservableCollection<Homework> homework = new ObservableCollection<Homework>();

        public ObservableCollection<Homework> Homework
        {
            get { return homework; }
            set { homework = value; OnPropertyChanged(nameof(Homework)); }
        }

        private ObservableCollection<Exam> exams = new ObservableCollection<Exam>();

        public ObservableCollection<Exam> Exams
        {
            get { return exams; }
            set { exams = value; OnPropertyChanged(nameof(Exams)); }
        }

        private ObservableCollection<Test> tests = new ObservableCollection<Test>();

        public ObservableCollection<Test> Tests
        {
            get { return tests; }
            set { tests = value; OnPropertyChanged(nameof(Tests)); }
        }

        public string WelcomeMessage
        {
            get { return $"Witaj {Student.Name}"; }
        }

        public string TodayDate
        {
            get { return $"Dzisiaj jest {DateTime.Today.ToString("dd/MM/yyyy")}"; }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetWindowHidden()
        {
            if (WelcomeScreenUserControl.Instance != null)
            {
                WelcomeScreenUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (WelcomeScreenUserControl.Instance != null)
            {
                WelcomeScreenUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void GetDutiesBeforeDeadline(int daysToDeadline)
        {
            Exams = GetExamsBeforeDeadline(daysToDeadline);
            Homework = GetHomeworkBeforeDeadline(daysToDeadline);
            Tests = GetTestsBeforeDeadline(daysToDeadline);
        }

        private ObservableCollection<Exam> GetExamsBeforeDeadline(int daysToDeadline)
        {

            try
            {
                return new ObservableCollection<Exam>
                           (LoginStudent.GetExamsData().ToList().
                           Where(exam => exam.DateOfExam.Subtract(DateTime.Today).Days <= daysToDeadline).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }

        private ObservableCollection<Homework> GetHomeworkBeforeDeadline(int daysToDeadline)
        {
            try
            {              
                return new ObservableCollection<Homework>
                           (LoginStudent.GetHomeworkData().ToList().
                           Where(homework => homework.DateOfEnd.Subtract(DateTime.Today).Days <= daysToDeadline).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private ObservableCollection<Test> GetTestsBeforeDeadline(int daysToDeadline)
        {
            try
            {
                return new ObservableCollection<Test>
                           (LoginStudent.GetTestsData().ToList().
                           Where(test => test.DateOfTest.Subtract(DateTime.Today).Days <= daysToDeadline).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
