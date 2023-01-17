using CommunityToolkit.Mvvm.Input;
using StudentsHelper.Model;
using StudentsHelper.Schedules;
using StudentsHelper.View.UserControls;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel.Commands;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class ScheduleVM : BaseViewModel
    {
        //This class refers to ScheduleUserControl.xaml
        public ScheduleVM()
        {
            Instance = this;
            Student = DataBase.ObjectsDataGetter.GetStudentData();
            ShowScheduleInstructionWindowCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(ShowScheduleInstructionWindow);
            GetScheduleCommand = new GetScheduleCommand(this);
            ScheduleImporter.SetSchedule();
        }

        private void ShowScheduleInstructionWindow()
        {
            ScheduleInstructionWindow ScheduleInstructionWindow = new();
            ScheduleInstructionWindow.Show();
        }

        public Student Student { get; set; }
        public static ScheduleVM? Instance { get; set; }
        public ICommand GetScheduleCommand { get; set; }
        public ICommand ShowScheduleInstructionWindowCommand { get; set; }

        private static bool isGetScheduleButtonEnabled = true;

        public bool IsGetScheduleButtonEnabled
        {
            get { return isGetScheduleButtonEnabled; }
            set { isGetScheduleButtonEnabled = value; OnPropertyChanged(nameof(IsGetScheduleButtonEnabled)); }
        }

        /// <summary>
        /// Dispose ScheduleWebBrowser in ScheduleUserControl
        /// </summary>
        public static void DisposeScheduleWebBrowser()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.ScheduleWebBrowser.Dispose();
            }
        }

        /// <summary>
        /// Initialize ScheduleWebBrowser in ScheduleUserControl, this control needs to invoke Dispose() explicitly
        /// </summary>
        public static void InitializeScheduleWebBrowser()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.ScheduleWebBrowser = new System.Windows.Controls.WebBrowser();
            }
        }
    }
}