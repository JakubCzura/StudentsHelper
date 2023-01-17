using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class HomeworkVM : BaseViewModel
    {
        //This class refers to HomeworkUserControl.xaml

        public HomeworkVM()
        {
            AddHomeworkCommand = new ShowWindowCommand();
            DeleteHomeworkCommand = new DeleteHomeworkCommand(this);
            ShowEditHomeworkCommand = new ShowEditHomeworkCommand();
            Instance = this;
            SortHomeworkDateAscending();
        }

        public static HomeworkVM? Instance { get; set; }

        private ObservableCollection<Homework> homework = ObjectsDataGetter.GetHomeworkData();

        public ICommand AddHomeworkCommand { get; set; }

        public ICommand DeleteHomeworkCommand { get; set; }

        public ICommand ShowEditHomeworkCommand { get; set; }

        public ObservableCollection<Homework> Homework
        {
            get { return homework; }
            set { homework = value; OnPropertyChanged(nameof(Homework)); }
        }

        private Homework selectedHomework { get; set; }

        public Homework SelectedHomework
        {
            get { return selectedHomework; }
            set { selectedHomework = value; OnPropertyChanged(nameof(SelectedHomework)); }
        }

        public void SortHomeworkDateAscending()
        {
            Homework = new ObservableCollection<Homework>(Homework.OrderBy(homework => homework.DateOfEnd));
        }
    }
}