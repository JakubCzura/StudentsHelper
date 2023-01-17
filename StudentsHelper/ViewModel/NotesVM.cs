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
    public class NotesVM : BaseViewModel
    {
        //This class refers to NotesUserControl.xaml
        public NotesVM()
        {
            AddNoteCommand = new RelayCommand(ShowAddNoteWindow);
            DeleteNoteCommand = new RelayCommand(DeleteNote);
            ShowEditNoteCommand = new RelayCommand(ShowEditNoteWindow);
            Instance = this;
            Notes = SortNotesDateAscending(ObjectsDataGetter.GetNotesData());
        }

        private void DeleteNote()
        {
            if (Notes != null && Notes.Any() == true)
            {
                if (DataDeletion.Delete(SelectedNote))
                {
                    Notes = ObjectsDataGetter.GetNotesData();
                    MessageBox.Show("Skasowano informację o notatce", "Zapisano pomyślnie");
                }
                else
                {
                    MessageBox.Show("Spróbuj skasować informację o notatce ponownie", "Błąd skasowania informacji o notatce");
                }
            }
        }
        private void ShowEditNoteWindow()
        {
            if (Notes != null && Notes.Any() == true)
            {
                EditNoteWindow EditNoteWindow = new EditNoteWindow();
                EditNoteWindow.Show();
            }
        }

        private void ShowAddNoteWindow()
        {
            AddNoteWindow AddNoteWindow = new();
            AddNoteWindow.Show();
        }


        public static NotesVM? Instance { get; private set; }

        private ObservableCollection<Note> notes;

        public ICommand AddNoteCommand { get; private set; }

        public ICommand DeleteNoteCommand { get; private set; }

        public ICommand ShowEditNoteCommand { get; private set; }

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged(nameof(Notes)); }
        }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value; OnPropertyChanged(nameof(SelectedNote)); }
        }

        public static ObservableCollection<Note> SortNotesDateAscending(ObservableCollection<Note> notes)
        {
           return new ObservableCollection<Note>(notes.OrderBy(note => note.Date));
        }
    }
}