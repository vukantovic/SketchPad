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
    /// Interaction logic for WindowBrush.xaml
    /// </summary>
    public partial class WindowBrush : Window
    {
        public WindowBrush(int brushSize, Color color)
        {
            InitializeComponent();
            sliderSize.Value = brushSize;
            sliderBlue.Value = color.B;
            sliderRed.Value = color.R;
            sliderGreen.Value = color.G;
            sliderOpacity.Value = color.A;
        }

        public int PenSize
        {
            get => (int)sliderSize.Value;
        }
        public Color PenColor
        {
            get => Color.FromArgb((byte)sliderOpacity.Value,(byte)sliderRed.Value,(byte)sliderGreen.Value,(byte)sliderBlue.Value);
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
