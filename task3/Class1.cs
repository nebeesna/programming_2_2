using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Point
    {
        private double x;
        private double y;
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double firstValue, double secondValue)
        {
            x = firstValue;
            y = secondValue;
        }
        public Point(Point other)
        {
            x = other.x;
            y = other.y;
        }
        public override string ToString()
        {
            return $"({this.x}, {this.y})";
        }
        public double Distance(Point otherPoint)
        {
            return Math.Sqrt(Math.Pow(otherPoint.x - this.x, 2) + Math.Pow(otherPoint.y - this.y, 2));
        }

    }
}
