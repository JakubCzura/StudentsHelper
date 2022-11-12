using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for TestsUserControl.xaml
    /// </summary>
    public partial class TestsUserControl : UserControl
    {
        public static TestsUserControl? Instance { get; private set; }

        public TestsUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}