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
using System.Windows.Shapes;

namespace SketchPad
{
    /// <summary>
    /// Interaction logic for WindowOpen.xaml
    /// </summary>
    public partial class WindowOpen : Window
    {
        public WindowOpen()
        {
            InitializeComponent();
        }

        public String Open
        {
            get => txtFile.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
