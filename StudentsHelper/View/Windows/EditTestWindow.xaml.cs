using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy EditTestWindow.xaml
    /// </summary>
    public partial class EditTestWindow : Window
    {
        public EditTestWindow? Instance { get; set; }

        public EditTestWindow()
        {
            Instance = this;
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}