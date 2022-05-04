using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsHelper.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy NotesUserControl.xaml
    /// </summary>
    public partial class NotesUserControl : UserControl
    {
        public static NotesUserControl? Instance { get; set; }   
        public NotesUserControl()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(NotesVM.Instance?.SelectedNote?.Id.ToString());
        }
    }
}
