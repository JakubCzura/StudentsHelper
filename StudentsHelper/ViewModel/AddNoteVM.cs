using StudentsHelper.DataBase;
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
    public class AddNoteVM : BaseViewModel
    {

        //This class refers to AddNoteWindow.xaml
        public AddNoteVM()
        {
            SaveNoteCommand = new SaveNoteCommand(this);
        }

        public Note Note { get; set; } = new Note { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public SaveNoteCommand SaveNoteCommand { get; set; }

  
        public string Name
        {
            get { return Note.Name; }
            set { Note.Name = value; OnPropertyChanged(Name); }
        }
    
        public string Content
        {
            get { return Note.Content; }
            set { Note.Content = value; OnPropertyChanged(Content) ; }
        }
        
        public DateTime Date
        {
            get { return Note.Date; }
            set { Note.Date = value; OnPropertyChanged(nameof(Date)); }
        }
    }
}

