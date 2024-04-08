using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Point 
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static bool operator ==(Point point1, object point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, object point2)
        {
            return !point1.Equals(point2);
        }

        public static Point operator + (Point point1, Point point2)
        {
            point1.X+=point2.X;
            point1.Y+=point2.Y;

            return point1;
        }

        public static Point operator -(Point point1, Point point2)
        {
            point1.X -= point2.X;
            point1.Y -= point2.Y;

            return point1;
        }

        public static Point operator -(Point point)
        {
            point.X = -point.X;
            point.Y = -point.Y;

            return point;
        }

        public static Point operator *(Point point1, float k)
        {
            point1.X *= k;
            point1.Y *= k;

            return point1;
        }

        public static float operator *(Point point1, Point point2)
        {
            return (point1.X * point2.X)+ (point1.Y * point2.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals (object? obj)
        {
            if (obj is null)
                return false;

            Point comparPoint = obj as Point;

            return (this.X == comparPoint.X && this.Y == comparPoint.Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
