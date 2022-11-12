using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy EditNoteWindow.xaml
    /// </summary>
    public partial class EditNoteWindow : Window
    {
        private EditNoteWindow? Instance { get; set; }

        public EditNoteWindow()
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