using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure square1 = new Square(5);
            IFigure square2 = new Square(7.5);
            IFigure circle1 = new Circle(new Point(1,8), 5);
            IFigure circle2 = new Circle(new Point(1,0), 4.9);
            IFigure triangle1 = new Triangle(3, 4, 5);
            IFigure triangle2 = new Triangle(8, 9 , 5);
            IFigure triangle3 = new Triangle(3.9, 5, 7);
            IFigure[] array = { square1, triangle1, circle1, square2, triangle2, circle2, triangle3 };
            double s = 0;
            foreach (IFigure figure in array)
            {
                s += figure.CountArea();
                Console.WriteLine($"S = {figure.CountArea()}");
            }
            Console.WriteLine($"Total Area = {s}");


            IFigure circle3 = new Circle(new Point(7,1), 9.3);
            IFigure circle4 = new Circle(new Point(3, 2), 3);

            IFigure[] arrayOfCircles = { circle1, circle2, circle3, circle4 };
            Console.WriteLine("\nBefore Sort:");
            foreach (IFigure circle in arrayOfCircles)
            {
                Console.WriteLine($"S = {circle.CountArea()}");
            }
            Array.Sort(arrayOfCircles);
            Console.WriteLine("\nAfter Sort:");
            foreach (IFigure circle in arrayOfCircles)
            {
                Console.WriteLine($"S = {circle.CountArea()}");
            }
            Circle theSmallestCircle = (Circle)arrayOfCircles[0];
            Circle theSmallestCircleClone = (Circle)theSmallestCircle.Clone();
            theSmallestCircleClone.Radius = 8;
            Console.WriteLine(theSmallestCircleClone.Radius);
            Console.WriteLine($"\nThe smallest circle: {theSmallestCircle}");
            Console.WriteLine($"\nThe smallest circle clone: {theSmallestCircleClone}");

        }
    }
}
