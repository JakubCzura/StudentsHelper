using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for PasswordChangeUserControl.xaml
    /// </summary>
    public partial class PasswordChangeUserControl : UserControl
    {
        public static PasswordChangeUserControl? Instance { get; set; }

        public PasswordChangeUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}