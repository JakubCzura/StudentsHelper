using StudentsHelper.Model;
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
        private ObservableCollection<Exam> exams = new ObservableCollection<Exam>()
        {
            //new Exam{ Name = "21", DateOfExam = new DateTime(200,1,21), Note="asa", RoomNumber=21, Teacher = null }
        };

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
