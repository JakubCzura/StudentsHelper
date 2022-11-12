using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddNoteWindow.xaml
    /// </summary>
    public partial class AddNoteWindow : Window
    {
        public AddNoteWindow? Instance { get; set; }

        public AddNoteWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}