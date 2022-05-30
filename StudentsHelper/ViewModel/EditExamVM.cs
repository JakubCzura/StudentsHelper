using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class EditExamVM : ExamsVM
    {
        public static new EditExamVM? Instance { get; set; }
        public EditExamVM()
        {
            Instance = this;
        }

        private Exam selectedExam { get; set; }
        public new Exam SelectedExam
        {
            get
            {
                return selectedExam;
            }
            set
            {
                selectedExam = value;
                OnPropertyChanged(nameof(SelectedExam));
            }
        }

        public new event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
