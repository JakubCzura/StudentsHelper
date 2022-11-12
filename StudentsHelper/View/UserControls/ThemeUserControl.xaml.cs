using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for ThemeUserControl.xaml
    /// </summary>
    public partial class ThemeUserControl : UserControl
    {
        public static ThemeUserControl? Instance { get; set; }

        public ThemeUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}