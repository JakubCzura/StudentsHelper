using StudentsHelper.Model;
using StudentsHelper.Schedules;
using StudentsHelper.ViewModel.Commands;

namespace StudentsHelper.ViewModel
{
    public class ScheduleVM : BaseViewModel
    {
        //This class refers to ScheduleUserControl.xaml
        public ScheduleVM()
        {
            Instance = this;
            Student = DataBase.LoginStudent.GetStudentData();
            ShowScheduleInstructionWindowCommand = new ShowScheduleInstructionWindowCommand();
            GetScheduleCommand = new GetScheduleCommand(this);
            ScheduleImporter.SetSchedule();
        }

        public Student Student { get; set; }
        public static ScheduleVM? Instance { get; set; }
        public GetScheduleCommand GetScheduleCommand { get; set; }
        public ShowScheduleInstructionWindowCommand ShowScheduleInstructionWindowCommand { get; set; }

        private static bool isGetScheduleButtonEnabled = true;
        public bool IsGetScheduleButtonEnabled
        {
            get { return isGetScheduleButtonEnabled; }
            set { isGetScheduleButtonEnabled = value; OnPropertyChanged(nameof(IsGetScheduleButtonEnabled)); } 
        }    
    }
}
