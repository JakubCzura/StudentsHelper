using StudentsHelper.Model;
using StudentsHelper.Schedules;
using StudentsHelper.View.UserControls;
using StudentsHelper.ViewModel.Commands;
using StudentsHelper.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class ScheduleVM : INotifyPropertyChanged, IVisibility
    {
        //This class refers to ScheduleUserControl.xaml
        public ScheduleVM()
        {
            Instance = this;
            WindowsVisibility.HideMainWindowDuties += SetHidden;
            Student = DataBase.LoginStudent.GetStudentData();
            ShowScheduleInstructionWindowCommand = new ShowScheduleInstructionWindowCommand();
            GetScheduleCommand = new GetScheduleCommand(this);
        }

        public Student Student { get; set; }
        public static ScheduleVM? Instance { get; set; }
        public GetScheduleCommand GetScheduleCommand { get; set; }
        public ShowScheduleInstructionWindowCommand ShowScheduleInstructionWindowCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private static bool isGetScheduleButtonEnabled = true;
        public bool IsGetScheduleButtonEnabled
        {
            get { return isGetScheduleButtonEnabled; }
            set { isGetScheduleButtonEnabled = value; OnPropertyChanged(nameof(IsGetScheduleButtonEnabled)); } 
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetHidden()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetVisible()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
