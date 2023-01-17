using CommunityToolkit.Mvvm.Input;
using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class AddNoteVM : BaseViewModel
    {
        //This class refers to AddNoteWindow.xaml
        public AddNoteVM()
        {
            SaveNoteCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(SaveNote);
        }

        private void SaveNote()
        {
            try
            {
                if (NoteDataValidator.ValidateNoteData(Note))
                {
                    if (DataSaving.Save(Note))
                    {
                        if (NotesVM.Instance != null)
                        {
                            NotesVM.Instance.Notes = ObjectsDataGetter.GetNotesData();
                            NotesVM.Instance.SortNotesDateAscending();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano notatkę");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać notatkę ponownie", "Błąd dodania notatki");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }

        public Note Note { get; set; } = new Note { StudentId = DataBaseHelper.StudentId };

        public ICommand SaveNoteCommand { get; private set; }

        public string Name
        {
            get { return Note.Name; }
            set { Note.Name = value; OnPropertyChanged(Name); }
        }

        public string Content
        {
            get { return Note.Content; }
            set { Note.Content = value; OnPropertyChanged(Content); }
        }

        public DateTime Date
        {
            get { return Note.Date; }
            set { Note.Date = value; OnPropertyChanged(nameof(Date)); }
        }
    }
}