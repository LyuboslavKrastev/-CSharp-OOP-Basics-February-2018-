using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var checks = int.Parse(input[1]);
            var rectangles = new HashSet<Rectangle>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                GetRectangle(rectangles, tokens);
            }

            for (int i = 0; i < checks; i++)
            {
                var tokens = Console.ReadLine().Split();
                GetResult(rectangles, tokens);
            }
        }

        private static void GetResult(HashSet<Rectangle> rectangles, string[] tokens)
        {
            var firstRectangle = rectangles.FirstOrDefault(r => r.Id == tokens[0]);
            var secondRectangle = rectangles.FirstOrDefault(r => r.Id == tokens[1]);
            Console.WriteLine(firstRectangle.IntersectWith(secondRectangle).ToString().ToLower());
        }

        private static void GetRectangle(HashSet<Rectangle> rectangles, string[] tokens)
        {
            var id = tokens[0];
            var width = double.Parse(tokens[1]);
            var height = double.Parse(tokens[2]);
            var x = double.Parse(tokens[3]);
            var y = double.Parse(tokens[4]);

            var rectangle = new Rectangle(id, width, height, x, y);
            rectangles.Add(rectangle);
        }
    }
}
