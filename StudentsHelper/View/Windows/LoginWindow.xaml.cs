using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static LoginWindow? Instance { get; set; }

        public LoginWindow()
        {
            Themes.Themes.SetTheme();
            InitializeComponent();
            Instance = this;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}