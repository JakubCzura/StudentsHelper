using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? Instance { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}