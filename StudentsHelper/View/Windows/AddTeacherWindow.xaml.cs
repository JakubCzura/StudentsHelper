using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        public AddTeacherWindow? Instance { get; set; }

        public AddTeacherWindow()
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