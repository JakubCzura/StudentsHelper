using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddExamWindow.xaml
    /// </summary>
    public partial class AddExamWindow : Window
    {
        public static AddExamWindow? Instance { get; private set; }

        public AddExamWindow()
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