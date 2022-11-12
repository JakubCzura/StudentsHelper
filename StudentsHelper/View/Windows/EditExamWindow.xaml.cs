using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        public EditExamWindow? Instance { get; set; }

        public EditExamWindow()
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