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
    public class TestVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to TestsUserControl.xaml
        public TestVM()
        {
            AddTestCommand = new ShowAddTestCommand();
            DeleteTestCommand = new DeleteTestCommand(this);
            ShowEditTestCommand = new ShowEditTestCommand();
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
            SortTestsDateAscending();
        }

        public static TestVM? Instance { get; set; }

        private ObservableCollection<Test> tests = LoginStudent.GetTestsData();

        public ShowAddTestCommand AddTestCommand { get; set; }

        public DeleteTestCommand DeleteTestCommand { get; set; }

        public ShowEditTestCommand ShowEditTestCommand { get; set; }

        public EditTestWindow EditTestWindow { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Test> Tests
        {
            get { return tests; }
            set { tests = value; OnPropertyChanged(nameof(Tests)); }
        }       

        private Test selectedTest;
        public Test SelectedTest
        {
            get { return selectedTest; }
            set { selectedTest = value; OnPropertyChanged(nameof(SelectedTest)); }
        }
        public void SetWindowHidden()
        {
            if (TestsUserControl.Instance != null)
            {
                TestsUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (TestsUserControl.Instance != null)
            {
                TestsUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SortTestsDateAscending()
        {
            Tests = new ObservableCollection<Test>(Tests.OrderBy(test => test.DateOfTest));
        }
    }
}
