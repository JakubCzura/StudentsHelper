using StudentsHelper.DataBase;
using StudentsHelper.DataValidators;
using StudentsHelper.Model;
using StudentsHelper.ViewModel.Commands;
using System.Windows;
using System;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class AddTeacherVM : BaseViewModel
    {
        //This class refers to AddHomeworkWindow.xaml
        public AddTeacherVM()
        {
            SaveTeacherCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(SaveTeacher);
        }

        private void SaveTeacher()
        {
            try
            {
                if (TeacherDataValidator.ValidateTeacherData(Teacher))
                {
                    if (DataSaving.Save(Teacher))
                    {
                        if (TeachersVM.Instance != null)
                        {
                            TeachersVM.Instance.Teachers = ObjectsDataGetter.GetTeachersData();
                        }
                        MessageBox.Show("Zapisano pomyślnie", "Dodano wykładowcę");
                    }
                    else
                    {
                        MessageBox.Show("Spróbuj dodać wykładowcę ponownie", "Błąd dodania wykładowcy");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\nProszę poprawić błędne dane", "Błąd zapisu");
            }
        }

        public Teacher Teacher { get; set; } = new Teacher { StudentLogin = DataBaseHelper.StudentLogin, StudentId = DataBaseHelper.StudentId };

        public ICommand SaveTeacherCommand { get; private set; }

        public string Lesson
        {
            get { return Teacher.Lesson; }
            set
            {
                Teacher.Lesson = value;
                OnPropertyChanged(Lesson);
            }
        }

        public string Name
        {
            get { return Teacher.Name; }
            set { Teacher.Name = value; OnPropertyChanged(Name); }
        }

        public string Degree
        {
            get { return Teacher.Degree; }
            set { Teacher.Degree = value; OnPropertyChanged(Degree); }
        }

        public int RoomNumber
        {
            get { return Teacher.RoomNumber; }
            set { Teacher.RoomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
        }

        public string LastName
        {
            get { return Teacher.LastName; }
            set { Teacher.LastName = value; OnPropertyChanged(LastName); }
        }

        public string Note
        {
            get { return Teacher.Note; }
            set { Teacher.Note = value; OnPropertyChanged(Note); }
        }
    }
}