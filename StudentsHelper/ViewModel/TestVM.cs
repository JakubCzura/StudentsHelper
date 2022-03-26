using StudentsHelper.DataBase;
using StudentsHelper.Model;
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
    public class TestVM : INotifyPropertyChanged
    {
        public static TestVM? Instance { get; set; }

        Teacher teacher = new Teacher();

        private ObservableCollection<Test> tests = LoginStudent.GetTestsData();

        public AddTestCommand AddTestCommand { get; set; }

        public TestVM()
        {
            AddTestCommand = new AddTestCommand(this);
            Instance = this;
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

        public ObservableCollection<Test> Tests
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
