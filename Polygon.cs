using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Polygon
    {
        public Point[] points;
        public readonly int VertexCount;
        public Polygon(int vertexCount)
        {
            VertexCount = vertexCount;
            points = new Point[VertexCount];
            for(int i =0;i!= VertexCount;++i)
                points[i] = new Point();
        }

        public Polygon(Point[] points)
        {
            VertexCount= points.Length;
            this.points = points;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            Polygon other = obj as Polygon;
            if (other is null) return false;
            if (other.VertexCount != VertexCount) return false;

            for(int i=0;i!= VertexCount;++i)
            {
                if (other.points[i] != this.points[i])
                    return false;
            }
            return true;
        }

        static public bool operator == (Polygon polygon1, Polygon polygon2)
        {
            return polygon1.Equals(polygon2);
        }
        static public bool operator !=(Polygon polygon1, Polygon polygon2)
        {
            return !polygon1.Equals(polygon2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Move(Vector2 vector)
        {
            for(int i=0;i!=VertexCount;++i)
            {
                this.points[i].X += vector.X;
                this.points[i].Y += vector.Y;
            }
        }

        public void Move(float x, float y)
        {
            Move(new Vector2(x, y));
        }

        public void MoveX(float x)
        {
            Move(new Vector2(x, 0.0f));
        }

        public void MoveY(float y)
        {
            Move(new Vector2(0.0f, y));
        }
    }
}
