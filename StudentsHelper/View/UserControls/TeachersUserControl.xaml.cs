using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for TeachersUserControl.xaml
    /// </summary>
    public partial class TeachersUserControl : UserControl
    {
        public static TeachersUserControl? Instance { get; set; }

        public TeachersUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}