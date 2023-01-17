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
    public class AddHomeworkVM : BaseViewModel
    {
        //This class refers to AddHomeworkWindow.xaml
        public AddHomeworkVM()
        {
            SaveHomeworkCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(SaveHomework);
        }

        private void SaveHomework()
        {
            try
            {
                if (HomeworkDataValidator.ValidateHomeworkData(Homework))
                {
                    if (DataSaving.Save(Homework))
                    {
                        if (HomeworkVM.Instance != null)
                        {
                            HomeworkVM.Instance.Homework = ObjectsDataGetter.GetHomeworkData();
                            //HomeworkVM.Instance.SortHomeworkDateAscending();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano zadanie domowe");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać pracę domową ponownie", "Błąd dodania pracy domowej");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }

        public Homework Homework { get; set; } = new Homework { StudentId = DataBaseHelper.StudentId };

        public ICommand SaveHomeworkCommand { get; private set; }

        public string LessonName
        {
            get { return Homework.LessonName; }
            set { Homework.LessonName = value; OnPropertyChanged(LessonName); }
        }

        public DateTime DateOfEnd
        {
            get { return Homework.DateOfEnd; }
            set { Homework.DateOfEnd = value; OnPropertyChanged(nameof(DateOfEnd)); }
        }

        public string TeacherName
        {
            get { return Homework.TeacherName; }
            set { Homework.TeacherName = value; OnPropertyChanged(TeacherName); }
        }

        public string TeacherSecondName
        {
            get { return Homework.TeacherSecondName; }
            set { Homework.TeacherSecondName = value; OnPropertyChanged(TeacherSecondName); }
        }

        public string Exercise
        {
            get { return Homework.Exercise; }
            set { Homework.Exercise = value; OnPropertyChanged(Exercise); }
        }

        public string Note
        {
            get { return Homework.Note; }
            set { Homework.Note = value; OnPropertyChanged(Note); }
        }
    }
}