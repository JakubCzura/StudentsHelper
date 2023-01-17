using CommunityToolkit.Mvvm.Input;
using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class TestsVM : BaseViewModel
    {
        //This class refers to TestsUserControl.xaml
        public TestsVM()
        {
            AddTestCommand = new RelayCommand(ShowAddTestWindow);
            DeleteTestCommand = new RelayCommand(DeleteTest);
            ShowEditTestCommand = new RelayCommand(ShowEditTestWindow);
            Instance = this;
            SortTestsDateAscending();
        }

        private void DeleteTest()
        {
            if (Tests != null && Tests.Any() == true)
            {
                if (DataDeletion.Delete(SelectedTest))
                {
                    Tests = ObjectsDataGetter.GetTestsData();
                    MessageBox.Show("Skasowano informację o teście", "Zapisano pomyślnie");
                }
                else
                {
                    MessageBox.Show("Spróbuj skasować informację o teście ponownie", "Błąd skasowania informacji o teście");
                }
            }
        }

        private void ShowAddTestWindow()
        {
            AddTestWindow AddTestWindow = new();
            AddTestWindow.Show();
        }

        private void ShowEditTestWindow()
        {
            if (Tests != null && Tests.Any())
            {
                EditTestWindow EditTestWindow = new();
                EditTestWindow.Show();
            }
        }

        public static TestsVM? Instance { get; set; }

        private ObservableCollection<Test> tests = ObjectsDataGetter.GetTestsData();

        public ICommand AddTestCommand { get; set; }

        public ICommand DeleteTestCommand { get; set; }

        public ICommand ShowEditTestCommand { get; set; }

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