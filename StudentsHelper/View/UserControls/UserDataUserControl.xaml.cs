using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserDataUserControl.xaml
    /// </summary>
    public partial class UserDataUserControl : UserControl
    {
        public static UserDataUserControl? Instance { get; set; }

        public UserDataUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}