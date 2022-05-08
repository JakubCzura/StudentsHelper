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
    public class TestVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to TestsUserControl.xaml
        public static TestVM? Instance { get; set; }

        private ObservableCollection<Test> tests = LoginStudent.GetTestsData();

        public AddTestCommand AddTestCommand { get; set; }

        public DeleteTestCommand DeleteTestCommand { get; set; }

        public TestVM()
        {
            AddTestCommand = new AddTestCommand(this);
            DeleteTestCommand = new DeleteTestCommand(this);
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
        }

        public ObservableCollection<Test> Tests
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }
        private Test selectedTest{ get; set; }
        public Test SelectedTest
        {
            get
            {
                return selectedTest;
            }
            set
            {
                selectedTest = value;
                OnPropertyChanged(nameof(SelectedTest));
            }
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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
