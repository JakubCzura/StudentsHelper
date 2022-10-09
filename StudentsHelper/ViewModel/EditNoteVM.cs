using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class EditNoteVM : BaseViewModel
    {
        public EditNoteVM()
        {
            SelectedNote = NotesVM.Instance.SelectedNote;
            SaveEditedNoteCommand = new SaveEditedNoteCommand(this);
            Instance = this;
        }

        public static EditNoteVM? Instance { get; set; }

        public SaveEditedNoteCommand SaveEditedNoteCommand { get; set; }
        
        
        public string Name
        {
            get { return SelectedNote.Name; }
            set { SelectedNote.Name = value; OnPropertyChanged(Name); }
        }

        public DateTime Date
        {
            get { return SelectedNote.Date; }
            set { SelectedNote.Date = value; OnPropertyChanged(nameof(Date)); }
        }

        public string Content
        {
            get { return SelectedNote.Content; }
            set { SelectedNote.Content = value; OnPropertyChanged(Content); }
        }

        private Note selectedNote;
        public Note SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value; OnPropertyChanged(nameof(SelectedNote)); }
        }
    }
}
