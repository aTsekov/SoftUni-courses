using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get { return _length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                _length = value;
            }
        }
        public double Width
        {
            get { return _width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
               _width = value;
            }
        }
        public double Height
        {
            get { return _height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                _height = value;
            }
        }

        public double SurfaceArea()
        {
            var area = (2 * (Length * Width)) + (2 * (Length * Height)) + (2 * (Width * Height));
            return area;
        }
        public double LateralSurfaceArea()
        {
            var lateralSurface = (2 * (Length * Height)) + (2 * (Width * Height));
            return lateralSurface;
        }
        public double Volume()
        {
            var volume = Length * Width * Height;
            return volume;
        }
    }
}
