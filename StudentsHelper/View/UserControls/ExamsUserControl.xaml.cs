using System.Windows.Controls;

namespace StudentsHelper.View.UserControls
{
    /// <summary>
    /// Interaction logic for ExamsUserControl.xaml
    /// </summary>
    public partial class ExamsUserControl : UserControl
    {
        public static ExamsUserControl? Instance { get; private set; }

        public ExamsUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}