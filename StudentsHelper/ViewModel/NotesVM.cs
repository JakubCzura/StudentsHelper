using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class NotesVM : BaseViewModel
    {
        //This class refers to NotesUserControl.xaml
        public NotesVM()
        {
            AddNoteCommand = new ShowWindowCommand();
            DeleteNoteCommand = new DeleteNoteCommand(this);
            ShowEditNoteCommand = new ShowEditNoteCommand();
            Instance = this;
            SortNotesDateAscending();
        }

        public static NotesVM? Instance { get; set; }

        private ObservableCollection<Note> notes = LoginStudent.GetNotesData();

        public ICommand AddNoteCommand { get; set; }
        
        public ICommand DeleteNoteCommand { get; set; }

        public ICommand ShowEditNoteCommand { get; set; }

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged(nameof(Notes)); }
        }

        private Note selectedNote { get; set; }
        public Note SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value; OnPropertyChanged(nameof(SelectedNote)); }
        }
    
        public void SortNotesDateAscending()
        {
            Notes = new ObservableCollection<Note>(Notes.OrderBy(note => note.Date));
        }
    }
}

