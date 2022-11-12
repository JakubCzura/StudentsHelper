using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        public static AddTestWindow? Instance { get; private set; }

        public AddTestWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}