﻿using System;
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
    /// Logika interakcji dla klasy WelcomeScreenUserControl.xaml
    /// </summary>
    public partial class WelcomeScreenUserControl : UserControl
    {
        public static WelcomeScreenUserControl? Instance { get; set; }
        public WelcomeScreenUserControl()
        {
            InitializeComponent();
            Instance = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("dasdasdasdadsa");
        }
    }
}