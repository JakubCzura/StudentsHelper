using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddHomeworkWindow.xaml
    /// </summary>
    public partial class AddHomeworkWindow : Window
    {
        public static AddHomeworkWindow? Instance { get; private set; }

        public AddHomeworkWindow()
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