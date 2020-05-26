using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SketchPad
{
    class Brush
    {
        int brushSize;
        public int BrushSize
        {
            get => brushSize;
            set => brushSize = value;
        }
        SolidColorBrush customBrush;
        public SolidColorBrush CustomBrush
        {
            get => customBrush;
            set => customBrush = value;
        }

        bool brushSelected;
        public bool BrushSelected
        {
            get => brushSelected;
            set => brushSelected = value;
        }

        public Brush(int brushSize, SolidColorBrush customBrush)
        {
            this.brushSize = brushSize;
            this.customBrush = customBrush;
            this.BrushSelected = true;
        }

        public override string ToString()
        {
            return $"Brush size: {brushSize}, Brush Color: {customBrush.Color.ToString()}";
        }
    }
}
