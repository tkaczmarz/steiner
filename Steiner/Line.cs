using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steiner
{
    public class Line
    {
        public PointF A { get { return a; } }
        public PointF B { get { return b; } }

        private PointF a;
        private PointF b;
        private float multiplier = 30;

        public Line(Point A, Point B)
        {
            a = new PointF((float)A.x * multiplier, (float)A.y * multiplier);
            b = new PointF((float)B.x * multiplier, (float)B.y * multiplier);
        }

        public static List<Line> GetLines(params Point[] points)
        {
            if (points.Length % 2 != 0)
                return null;

            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Length - 1; i += 2)
            {
                lines.Add(new Line(points[i], points[i + 1]));
            }
            return lines;
        }
    }
}
