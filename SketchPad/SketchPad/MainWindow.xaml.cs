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

namespace SketchPad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        public void Open()
        {
            MessageBox.Show("");
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }
        Point currentPoint = new Point();
        private void BackGround_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentPoint = e.GetPosition(this);
        }
        int potez = 0;
        List<int> potezi = new List<int>();
        private void BackGround_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentPoint.X > 0)
            {
                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y - Menu.Height;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y - Menu.Height;
                currentPoint = e.GetPosition(this);
                BackGround.Children.Add(line);
                potez++;
            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (BackGround.Children.Count > 0)
            {
                for (int i = 0; i < potezi[potezi.Count - 1]; i++)
                    BackGround.Children.RemoveAt(BackGround.Children.Count - 1);
                potezi.RemoveAt(potezi.Count - 1);
            }
        }

        private void BackGround_MouseUp(object sender, MouseButtonEventArgs e)
        {
            potezi.Add(potez);
            potez = 0;
            currentPoint.X = -1;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            potezi.Clear();
            BackGround.Children.Clear();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            BackGround.Children.Clear();
            potezi.Clear();
            WindowOpen open = new WindowOpen();
            var result = open.ShowDialog();
            if ((bool)result)
            {
                System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
                myImage.Source = new BitmapImage(new Uri(open.Open));
                BackGround.Children.Add(myImage);
                potezi.Add(1);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)BackGround.RenderSize.Width,
            (int)BackGround.RenderSize.Height, 96d,1080, System.Windows.Media.PixelFormats.Default);
            rtb.Render(BackGround);
            var target = new RenderTargetBitmap((int)(BackGround.RenderSize.Width), (int)(BackGround.RenderSize.Height), 96, 96, PixelFormats.Pbgra32);
            var brush = new VisualBrush(BackGround);

            var visual = new DrawingVisual();
            var drawingContext = visual.RenderOpen();


            drawingContext.DrawRectangle(brush, null, new Rect(new Point(0, 0),
                new Point(BackGround.RenderSize.Width, BackGround.RenderSize.Height)));

            drawingContext.Close();

            target.Render(visual);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(target));
            WindowSave save = new WindowSave();
            var result = save.ShowDialog();
            if ((bool)result)
            {
                MessageBox.Show(save.Save);
                using (var fs = System.IO.File.OpenWrite(save.Save.ToString()))
                {
                    pngEncoder.Save(fs);
                }
                
            }
        }
    }
}
//C:\Users\vukan\Desktop