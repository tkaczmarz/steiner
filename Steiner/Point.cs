using System;
using System.Collections.Generic;

namespace Steiner
{
    public class Point : IComparable
    {
        public double x;
        public double y;

        private double Value { get { return x + y; } }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static List<Point> GetList(params double[] coords)
        {
            if (coords.Length % 2 != 0)
                return new List<Point>();

            List<Point> list = new List<Point>();
            for (int i = 0; i < coords.Length - 1; i += 2)
            {
                list.Add(new Point(coords[i], coords[i + 1]));
            }

            return list;
        }

        public bool LessThan(Point q)
        {
            if (q.Value < Value || (q.Value == Value && x < q.x))
            {
                return true;
            }
            else
                return false;
        }

        public Point Merge(Point q)
        {
            double minX = x < q.x ? x : q.x;
            double minY = y < q.y ? y : q.y;
            
            return new Point(minX, minY);
        }

        public double Cost(Point q)
        {
            return Math.Abs(x - q.x) + Math.Abs(y - q.y);
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        public int CompareTo(object obj)
        {
            Point p = obj as Point;
            if (p != null)
            {
                if (LessThan(p))
                    return -1;
                else
                    return 1;
            }
            else
                throw new Exception("Object is not a point!");
        }
    }
}
