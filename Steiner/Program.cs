using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Steiner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> Q = Point.GetList(0, 0, 1, 2, 2, 4, 3, 1, 3, 2, 4, 2, 4, 4, 5, 1);
            List<Line> G = new List<Line>();

            Q.Sort();

            Console.WriteLine("Points in order:");
            foreach (Point p in Q)
                Console.WriteLine(p);

            while (Q.Count > 1)
            {
                Point a = Q[0];
                Point b = Q[1];
                Point merged = a.Merge(b);
                
                G.Add(new Line(a, merged));
                G.Add(new Line(b, merged));
                Q[0] = merged;
                Q.RemoveAt(1);
                Q.Sort();
            }

            //Application.Run(new DrawingForm(Line.GetLines(Point.GetList(0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 3, 1, 3, 1, 5, 1, 1, 1, 1, 2, 1, 2, 2, 2, 2, 2, 3, 2, 3, 2, 4, 2, 2, 2, 2, 4, 2, 4, 4, 4).ToArray())));
            Application.Run(new DrawingForm(G));

            Console.ReadKey();
        }
    }
}
