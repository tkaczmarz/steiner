using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Steiner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Współrzędne punktów z przykładu z wykładu
            List<Point> Q = Point.GetList(0, 0, 1, 2, 2, 4, 3, 1, 3, 2, 4, 2, 4, 4, 5, 1);
            List<Line> G = new List<Line>();

            Console.WriteLine("Added points:");
            foreach (Point p in Q)
                Console.WriteLine(p);

            while (Q.Count > 1)
            {
                Point p = Q[0];
                Point q = Q[1];
                Point min = p.Merge(q);
                for (int i = 0; i < Q.Count; i++)
                {
                    for (int j = 0; j < Q.Count; j++)
                    {
                        if (i == j)
                            continue;
                        
                        Point merged = Q[i].Merge(Q[j]);
                        if (merged.LessThan(min))
                        {
                            min = merged;
                            p = Q[i];
                            q = Q[j];
                        }
                    }
                }
                
                Q.Remove(p);
                Q.Remove(q);
                Q.Add(min);
                G.Add(new Line(p, min));
                G.Add(new Line(q, min));
            }
            
            Application.Run(new DrawingForm(G));

            Console.ReadKey();
        }
    }
}
