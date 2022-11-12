using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for NotesUserControl.xaml
    /// </summary>
    public partial class NotesUserControl : UserControl
    {
        public static NotesUserControl? Instance { get; set; }

        public NotesUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}