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
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SketchPad
{
    public partial class MainWindow : Window
    {
        Brush brush = new Brush(5, new SolidColorBrush(Colors.Red));
        public MainWindow()
        {
            InitializeComponent();
            brush.BrushSize = 5;
            sldSize.Value = brush.BrushSize;
            Brush.Background = Brushes.Blue;
            Brush.Foreground = Brushes.White;
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
            redoPotezi = new List<int>();
            redoContent = new List<UIElement>();
            currentPoint = e.GetPosition(this);
        }

        int potez = 0;
        List<int> redoPotezi = new List<int>();
        List<UIElement> redoContent = new List<UIElement>();
        List<int> undoPotezi = new List<int>();

        private void BackGround_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentPoint.X > 0 && currentPoint.Y > Menu.Height + brush.BrushSize)
            {
                if(brush.BrushSelected)
                {
                    Ellipse ellipse = new Ellipse { Width = brush.BrushSize, Height = brush.BrushSize };
                    ellipse.Stroke = brush.CustomBrush;
                    ellipse.StrokeThickness = brush.BrushSize + 5;
                    cnsBackground.Children.Add(ellipse);
                    Canvas.SetTop(ellipse, e.GetPosition(this).Y - Menu.Height - brush.BrushSize / 2);
                    Canvas.SetLeft(ellipse, e.GetPosition(this).X - brush.BrushSize / 2);
                    potez++;
                    currentPoint = e.GetPosition(this);
                }
                else
                {
                    Ellipse ellipse = new Ellipse { Width = brush.BrushSize, Height = brush.BrushSize };
                    ellipse.Stroke = new SolidColorBrush(Colors.White);
                    ellipse.StrokeThickness = brush.BrushSize + 5;
                    cnsBackground.Children.Add(ellipse);
                    Canvas.SetTop(ellipse, e.GetPosition(this).Y - Menu.Height - brush.BrushSize / 2);
                    Canvas.SetLeft(ellipse, e.GetPosition(this).X - brush.BrushSize / 2);
                    potez++;
                    currentPoint = e.GetPosition(this);
                }

            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (cnsBackground.Children.Count > 0)
            {
                for (int i = 0; i < undoPotezi[undoPotezi.Count - 1]; i++)
                {
                    redoContent.Add(cnsBackground.Children[cnsBackground.Children.Count - 1]);
                    cnsBackground.Children.RemoveAt(cnsBackground.Children.Count - 1);
                }
                redoPotezi.Add(undoPotezi[undoPotezi.Count - 1]);
                undoPotezi.RemoveAt(undoPotezi.Count - 1);
            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if(redoPotezi.Count > 0)
            {
                for (int i = 0; i < redoPotezi[redoPotezi.Count - 1]; i++)
                {
                    cnsBackground.Children.Add(redoContent[redoContent.Count - 1]);
                    redoContent.RemoveAt(redoContent.Count - 1);
                }
                undoPotezi.Add(redoPotezi[redoPotezi.Count - 1]);
                redoPotezi.RemoveAt(redoPotezi.Count - 1);
            }
        }

        private void BackGround_MouseUp(object sender, MouseButtonEventArgs e)
        {
            undoPotezi.Add(potez);
            potez = 0;
            currentPoint.X = -1;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            redoPotezi = undoPotezi;
            undoPotezi = new List<int>();
            foreach(UIElement element in cnsBackground.Children)
            {
                redoContent.Add(element);
            }
            cnsBackground.Children.Clear();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            cnsBackground.Children.Clear();
            undoPotezi.Clear();
            WindowOpen open = new WindowOpen();
            var result = open.ShowDialog();
            if ((bool)result)
            {
                System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
                myImage.Source = new BitmapImage(new Uri(open.Open));
                cnsBackground.Children.Add(myImage);
                undoPotezi.Add(1);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)cnsBackground.RenderSize.Width,
            (int)cnsBackground.RenderSize.Height, 96d,1080, System.Windows.Media.PixelFormats.Default);
            rtb.Render(cnsBackground);
            var target = new RenderTargetBitmap((int)(cnsBackground.RenderSize.Width), (int)(cnsBackground.RenderSize.Height), 96, 96, PixelFormats.Pbgra32);
            var brush = new VisualBrush(cnsBackground);

            var visual = new DrawingVisual();
            var drawingContext = visual.RenderOpen();


            drawingContext.DrawRectangle(brush, null, new Rect(new Point(0, 0),
                new Point(cnsBackground.RenderSize.Width, cnsBackground.RenderSize.Height)));

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

        private void Brush_Click(object sender, RoutedEventArgs e)
        {
            if(!brush.BrushSelected)
            {
                brush.BrushSelected = true;
                Brush.Background = Brushes.Blue;
                Brush.Foreground = Brushes.White;
                Erase.Background = Brushes.Transparent;
                Erase.Foreground = Brushes.Black;
            }
            else
            {
                WindowBrush window = new WindowBrush(brush.BrushSize, brush.CustomBrush.Color);
                var result = window.ShowDialog();
                if ((bool)result)
                {
                    sldSize.Value = window.PenSize;
                    brush.CustomBrush.Color = window.PenColor;
                }
            }
        }

        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            brush.BrushSelected = false;
            Brush.Background = Brushes.Transparent;
            Brush.Foreground = Brushes.Black;
            Erase.Background = Brushes.Blue;
            Erase.Foreground = Brushes.White;

        }

        private void sldSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            brush.BrushSize = (int)sldSize.Value;
        }
    }
}
//C:\Users\vukan\Desktop

/*Line line = new Line();
line.Stroke = new SolidColorBrush(color);
line.StrokeThickness = brushSize - 10;
line.X1 = currentPoint.X;
line.Y1 = currentPoint.Y - Menu.Height + (brushSize + 5)/2;
currentPoint = e.GetPosition(this);
line.X2 = e.GetPosition(this).X;
line.Y2 = e.GetPosition(this).Y - Menu.Height + (brushSize +5)/ 2;
BackGround.Children.Add(line);*/
