using StudentsHelper.Schedules;
using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for ScheduleUserControl.xaml
    /// </summary>
    public partial class ScheduleUserControl : UserControl
    {
        public static ScheduleUserControl? Instance { get; set; }

        public ScheduleUserControl()
        {
            InitializeComponent();
            Instance = this;
            ScheduleImporter.SetSchedule();
        }
    }
}