using StudentsHelper.DataBase;
using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace StudentsHelper.ViewModel
{
    public class WelcomeScreenVM : BaseViewModel
    {
        //This class refers to WelcomeScreenUserControl.xaml
        public WelcomeScreenVM()
        {
            Instance = this;
            SelectedDaysToDeadline = 5;
            Tests = ObjectsDataGetter.GetTestsData();
            Homework = ObjectsDataGetter.GetHomeworkData();
            Exams = ObjectsDataGetter.GetExamsData();
            Student = ObjectsDataGetter.GetStudentData();
            GetDutiesBeforeDeadline(SelectedDaysToDeadline);
        }

        public static WelcomeScreenVM? Instance { get; set; }

        private Student student;

        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        private readonly List<int> daysToDeadline = new() { 5, 10, 15 };

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

        private ObservableCollection<Homework> homework = new();

        public ObservableCollection<Homework> Homework
        {
            get { return homework; }
            set { homework = value; OnPropertyChanged(nameof(Homework)); }
        }

        private ObservableCollection<Exam> exams = new();

        public ObservableCollection<Exam> Exams
        {
            get { return exams; }
            set { exams = value; OnPropertyChanged(nameof(Exams)); }
        }

        private ObservableCollection<Test> tests = new();

        public ObservableCollection<Test> Tests
        {
            get { return tests; }
            set { tests = value; OnPropertyChanged(nameof(Tests)); }
        }

        public string WelcomeMessage
        {
            get { return $"Witaj {Student.Name}"; }
        }

        public static string TodayDate
        {
            get { return $"Dzisiaj jest {DateTime.Today:dd/MM/yyyy}"; }
        }

        private void GetDutiesBeforeDeadline(int daysToDeadline)
        {
            Exams = GetExamsBeforeDeadline(daysToDeadline);
            Homework = GetHomeworkBeforeDeadline(daysToDeadline);
            Tests = GetTestsBeforeDeadline(daysToDeadline);
        }

        private static ObservableCollection<Exam> GetExamsBeforeDeadline(int daysToDeadline)
        {
            try
            {
                return new ObservableCollection<Exam>
                           (ObjectsDataGetter.GetExamsData().ToList().
                           Where(exam => exam.DateOfExam.Subtract(DateTime.Today).Days <= daysToDeadline).
                           OrderBy(exam => exam.DateOfExam).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private static ObservableCollection<Homework> GetHomeworkBeforeDeadline(int daysToDeadline)
        {
            try
            {
                return new ObservableCollection<Homework>
                           (ObjectsDataGetter.GetHomeworkData().ToList().
                           Where(homework => homework.DateOfEnd.Subtract(DateTime.Today).Days <= daysToDeadline).
                           OrderBy(homework => homework.DateOfEnd).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private static ObservableCollection<Test> GetTestsBeforeDeadline(int daysToDeadline)
        {
            try
            {
                return new ObservableCollection<Test>
                           (ObjectsDataGetter.GetTestsData().ToList().
                           Where(test => test.DateOfTest.Subtract(DateTime.Today).Days <= daysToDeadline).
                           OrderBy(test => test.DateOfTest).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}