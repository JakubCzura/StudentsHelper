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
    public class HomeworkVM : BaseViewModel
    {
        //This class refers to HomeworkUserControl.xaml

        public HomeworkVM()
        {
            AddHomeworkCommand = new RelayCommand(ShowAddHomeworkWindow);
            DeleteHomeworkCommand = new RelayCommand(DeleteHomework);
            ShowEditHomeworkCommand = new RelayCommand(ShowEditHomeworkWindow);
            Instance = this;
            Homework = SortHomeworkDateAscending(ObjectsDataGetter.GetHomeworkData());
        }

        private void DeleteHomework()
        {
            if (Homework != null && Homework.Any() == true)
            {
                if (DataDeletion.Delete(SelectedHomework))
                {
                    Homework = ObjectsDataGetter.GetHomeworkData();
                    MessageBox.Show("Skasowano informację o zadaniu domowym", "Zapisano pomyślnie");
                }
                else
                {
                    MessageBox.Show("Spróbuj skasować informację o zadaniu domowym ponownie", "Błąd skasowania informacji o zadaniu domowym");
                }
            }
        }

        private void ShowEditHomeworkWindow()
        {
            if (Homework != null && Homework.Any() == true)
            {
                EditHomeworkWindow EditHomeworkWindow = new EditHomeworkWindow();
                EditHomeworkWindow.Show();
            }
        }

        private void ShowAddHomeworkWindow()
        {
            AddHomeworkWindow AddHomeworkWindow = new();
            AddHomeworkWindow.Show();
        }

        public static HomeworkVM? Instance { get; set; }

        private ObservableCollection<Homework> homework;

        public ICommand AddHomeworkCommand { get; private set; }

        public ICommand DeleteHomeworkCommand { get; private set; }

        public ICommand ShowEditHomeworkCommand { get; private set; }

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

        public static ObservableCollection<Homework> SortHomeworkDateAscending(ObservableCollection<Homework> homework)
        {
            return new ObservableCollection<Homework>(homework.OrderBy(homework => homework.DateOfEnd));
        }
    }
}