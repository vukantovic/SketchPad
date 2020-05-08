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
using System.Windows.Shapes;

namespace SketchPad
{
    /// <summary>
    /// Interaction logic for WindowSave.xaml
    /// </summary>
    public partial class WindowSave : Window
    {
        public WindowSave()
        {
            InitializeComponent();
        }
        public String Save
        {
            get => txtFile.Text + "\\" + txtName.Text + ".jpg";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
