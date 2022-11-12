using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy EditHomeworkWindow.xaml
    /// </summary>
    public partial class EditHomeworkWindow : Window
    {
        private EditHomeworkWindow? Instance { get; set; }

        public EditHomeworkWindow()
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