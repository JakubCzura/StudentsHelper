using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class ExamsVM : BaseViewModel
    {
        //This class refers to ExamsUserControl.xaml
        public ExamsVM()
        {
            AddExamCommand = new ShowWindowCommand();
            DeleteExamCommand = new DeleteExamCommand(this);
            ShowEditExamCommand = new ShowEditExamCommand();
            Instance = this;
            SortExamsDateAscending();
        }

        public static ExamsVM? Instance { get; set; }

        private ObservableCollection<Exam> exams = StudentLoggingIn.GetExamsData();

        public ICommand AddExamCommand { get; set; }

        public ICommand DeleteExamCommand { get; set; }

        public ICommand ShowEditExamCommand { get; set; }

        public ObservableCollection<Exam> Exams
        {
            get { return exams; }
            set { exams = value; OnPropertyChanged(nameof(Exams)); }
        }

        private Exam selectedExam { get; set; }

        public Exam SelectedExam
        {
            get { return selectedExam; }
            set { selectedExam = value; OnPropertyChanged(nameof(SelectedExam)); }
        }

        public void SortExamsDateAscending()
        {
            Exams = new ObservableCollection<Exam>(Exams.OrderBy(exam => exam.DateOfExam));
        }
    }
}