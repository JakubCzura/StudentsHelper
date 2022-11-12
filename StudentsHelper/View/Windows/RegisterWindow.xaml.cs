using System.Windows;

namespace StudentsHelper.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public static RegisterWindow? Instance { get; private set; }

        public RegisterWindow()
        {
            InitializeComponent();
            Instance = this;
            AgeTextBox.Text = "";
            SemesterTextBox.Text = "";
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}