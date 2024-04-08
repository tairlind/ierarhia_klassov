using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ColorPoint : Point
    {
        public UInt32 Color { get; set; }

        public ColorPoint() : base()
        {
            Color = 0xFFFFFFFF;
        }

        public ColorPoint(float X, float Y) : base(X, Y)
        {
            Color = 0xFFFFFFFF;
        }

        public ColorPoint(float X, float Y, UInt32 color) : base(X, Y)
        {
            Color = color;
        }

        public ColorPoint(ColorPoint colorPoint) : base(colorPoint.X,colorPoint.Y)
        {
            Color = colorPoint.Color;
        }

        public static ColorPoint operator + (ColorPoint colorPoint1, ColorPoint colorPoint2)
        {
            colorPoint1.X += colorPoint2.X;
            colorPoint1.Y += colorPoint2.Y;
            colorPoint1.Color= colorPoint1.Color | colorPoint2.Color;

            return colorPoint1;
        }

        public static bool operator ==(ColorPoint point1, object point2)
        {
            return point1.Equals(point2);
        }
        public static bool operator !=(ColorPoint point1, object point2)
        {
            return !point1.Equals(point2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals (object? obj)
        {
            if(obj is ColorPoint)//Объект - цветная точка
                return(this.X == (obj as ColorPoint).X &&
                    this.Y == (obj as ColorPoint).Y &&
                    this.Color == (obj as ColorPoint).Color);
            if(obj is Point)//Объект - точка
                return (this.X == (obj as Point).X &&
                    this.Y == (obj as Point).Y);

            return false;
        }

        public override string ToString()
        {
            return base.ToString() + "; 0x" + Color.ToString("X");
        }
    }
}

