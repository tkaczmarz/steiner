using System;
using System.Collections.Generic;

namespace Steiner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> Q = Point.GetList(0, 0, 1, 2, 2, 4, 3, 1, 3, 2, 4, 2, 4, 4, 5, 1);
            List<Point> G = new List<Point>();

            Q.Sort();

            foreach (Point p in Q)
                Console.WriteLine(p);

            while (Q.Count > 1)
            {
                Point a = Q[0];
                Point b = Q[1];
                Point merged = a.Merge(b);
                G.Add(merged);
                Q[0] = merged;
                Q.RemoveAt(1);
            }

            for (int i = 0; i < G.Count - 1; i++)
            {
                Console.WriteLine(G[i] + " -> " + G[i + 1]);
            }

            Console.ReadKey();
        }
    }
}
