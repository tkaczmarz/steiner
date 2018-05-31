using System;
using System.Collections.Generic;

namespace Steiner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = Point.GetList(0, 0, 1, 2, 2, 4, 3, 1, 3, 2, 4, 2, 4, 4, 5, 1);

            foreach (Point p in points)
                Console.WriteLine(p);

            Console.ReadKey();
        }
    }
}
