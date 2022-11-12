using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy EditTeacherWindow.xaml
    /// </summary>
    public partial class EditTeacherWindow : Window
    {
        private EditTeacherWindow? Instance { get; set; }

        public EditTeacherWindow()
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