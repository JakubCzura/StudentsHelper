using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for WelcomeScreenUserControl.xaml
    /// </summary>
    public partial class WelcomeScreenUserControl : UserControl
    {
        public static WelcomeScreenUserControl? Instance { get; set; }

        public WelcomeScreenUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}