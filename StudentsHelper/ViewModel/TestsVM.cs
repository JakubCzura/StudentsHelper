using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentsHelper.ViewModel
{
    public class TestsVM : BaseViewModel
    {
        //This class refers to TestsUserControl.xaml
        public TestsVM()
        {
            AddTestCommand = new ShowAddTestCommand();
            DeleteTestCommand = new DeleteTestCommand(this);
            ShowEditTestCommand = new ShowEditTestCommand();
            Instance = this;
            SortTestsDateAscending();
        }

        public static TestsVM? Instance { get; set; }

        private ObservableCollection<Test> tests = LoginStudent.GetTestsData();

        public ShowAddTestCommand AddTestCommand { get; set; }

        public DeleteTestCommand DeleteTestCommand { get; set; }

        public ShowEditTestCommand ShowEditTestCommand { get; set; }

        public EditTestWindow EditTestWindow { get; set; }

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

        public void SortTestsDateAscending()
        {
            Tests = new ObservableCollection<Test>(Tests.OrderBy(test => test.DateOfTest));
        }
    }
}
