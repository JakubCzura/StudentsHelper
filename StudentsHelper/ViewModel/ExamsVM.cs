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
    public class ExamsVM : BaseViewModel
    {
        //This class refers to ExamsUserControl.xaml
        public ExamsVM()
        {
            AddExamCommand = new RelayCommand(ShowAddExamWindow);
            DeleteExamCommand = new RelayCommand(DeleteExam);
            ShowEditExamCommand = new RelayCommand(ShowEditExamWindow);
            Instance = this;
            Exams = SortExamsDateAscending(ObjectsDataGetter.GetExamsData());
        }

        private void DeleteExam()
        {
            if (Exams != null && Exams.Any() == true)
            {
                if (DataDeletion.Delete(SelectedExam))
                {
                    Exams = ObjectsDataGetter.GetExamsData();
                    MessageBox.Show("Skasowano informację o egzaminie", "Zapisano pomyślnie");
                }
                else
                {
                    MessageBox.Show("Spróbuj skasować informację o egzaminie ponownie", "Błąd skasowania informacji o egzaminie");
                }
            }
        }

        private void ShowAddExamWindow()
        {
            AddExamWindow AddExamWindow = new();
            AddExamWindow.Show();
        }

        public static ExamsVM? Instance { get; set; }

        private ObservableCollection<Exam> exams;

        public ICommand AddExamCommand { get; private set; }

        public ICommand DeleteExamCommand { get; private set; }

        public ICommand ShowEditExamCommand { get; private set; }

        private void ShowEditExamWindow()
        {
            if (Exams != null && Exams.Any() == true)
            {
                EditExamWindow EditExamWindow = new();
                EditExamWindow.Show();
            }
        }

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

        public static ObservableCollection<Exam> SortExamsDateAscending(ObservableCollection<Exam> exams)
        {
            return new ObservableCollection<Exam>(exams.OrderBy(exam => exam.DateOfExam));
        }
    }
}