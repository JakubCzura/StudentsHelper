using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for SettingsUserControl.xaml
    /// </summary>
    public partial class SettingsUserControl : UserControl
    {
        public static SettingsUserControl? Instance { get; set; }

        public SettingsUserControl()
        {
            Instance = this;
            InitializeComponent();
        }
    }
}