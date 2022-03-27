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
    /// Logika interakcji dla klasy HomeworkUserControl.xaml
    /// </summary>
    public partial class HomeworkUserControl : UserControl
    {
        public static HomeworkUserControl? Instance { get; private set; }
        public HomeworkUserControl()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
