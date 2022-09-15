using StudentsHelper.Model;
using StudentsHelper.Schedules;
using StudentsHelper.UserControls;
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
    public class ScheduleVM : INotifyPropertyChanged, IWindowVisibility
    {
        //This class refers to ScheduleUserControl.xaml
        public ScheduleVM()
        {
            Instance = this;
            WindowsVisibility.HideWindow += SetWindowHidden;
            Student = DataBase.LoginStudent.GetStudentData();
            ShowScheduleInstructionWindowCommand = new ShowScheduleInstructionWindowCommand();
            GetScheduleCommand = new GetScheduleCommand(this);
        }

        public Student Student { get; set; }
        public static ScheduleVM? Instance { get; set; }
        public GetScheduleCommand GetScheduleCommand { get; set; }
        public ShowScheduleInstructionWindowCommand ShowScheduleInstructionWindowCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetWindowHidden()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void SetWindowVisible()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
