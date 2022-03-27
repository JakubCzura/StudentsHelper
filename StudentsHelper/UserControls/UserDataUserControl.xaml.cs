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
    /// Logika interakcji dla klasy UserDataUserControl.xaml
    /// </summary>
    public partial class UserDataUserControl : UserControl
    {
        public static UserDataUserControl? UserDataUserControlInstance { get; private set; }
        public UserDataUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
