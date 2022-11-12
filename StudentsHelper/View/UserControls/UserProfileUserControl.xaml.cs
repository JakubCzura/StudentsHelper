using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserProfileUserControl.xaml
    /// </summary>
    public partial class UserProfileUserControl : UserControl
    {
        public static UserProfileUserControl? Instance { get; set; }

        public UserProfileUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}