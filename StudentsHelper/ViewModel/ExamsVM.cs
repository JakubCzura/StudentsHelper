using StudentsHelper.Model;
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
    internal class ExamsVM : INotifyPropertyChanged
    {
        Teacher teacher = new Teacher();

        private ObservableCollection<Exam> exams = new ObservableCollection<Exam>()
        {
            new Exam("Angielski", new DateTime(200,1,21), 21, "Super zajęcia" ),
            new Exam("Angielski", new DateTime(200,1,21), 22, "Super zajęcia" ),
            new Exam("Angielski", new DateTime(200,1,21), 21, "Super zajęcia Super zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęciaSuper zajęcia" )
        };

        public AddExamCommand AddExamCommand { get; set; }

        public ExamsVM()
        {
            AddExamCommand = new AddExamCommand(this);
        }

        public string TeacherFullName
        {
            get { return teacher.ToString(); }
        }

        public Teacher Teacher
        {
            set 
            { 
                teacher = value; 
                OnPropertyChanged(nameof(Teacher)); 
            }        
        }
            

        public ObservableCollection<Exam> Exams
        { 
            get { return exams; }
            set 
            { 
                exams = value; 
                OnPropertyChanged(nameof(Exams));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
