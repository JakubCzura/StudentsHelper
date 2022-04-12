using StudentsHelper.DataBase;
using StudentsHelper.Model;
using StudentsHelper.UserControls;
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
    public class NotesVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to HomeworkUserControl.xaml

        public static NotesVM? Instance { get; set; }

        private ObservableCollection<Note> notes = LoginStudent.GetNotesData();

        public AddNoteCommand AddNoteCommand { get; set; }

        public NotesVM()
        {
            AddNoteCommand = new AddNoteCommand(this);
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
        }

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetWindowHidden()
        {
            if (NotesUserControl.Instance != null)
            {
                NotesUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (NotesUserControl.Instance != null)
            {
                NotesUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}

