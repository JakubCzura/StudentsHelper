using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for HomeworkUserControl.xaml
    /// </summary>
    public partial class HomeworkUserControl : UserControl
    {
        public static HomeworkUserControl? Instance { get; private set; }

        public HomeworkUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}