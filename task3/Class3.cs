using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Circle : IFigure, IComparable, ICloneable
    {
        private Point center;
        private double radius;
        public double Radius { get; set; }
        public Circle()
        {
            center = new Point();
            radius = 0;
        }
        public Circle(Point c, double r)
        {
            center = c;
            radius = r;
        }
        public double CountArea()
        {
            return Math.PI * radius * radius;
        }
        public int CompareTo(object obj)
        {
            Circle other = obj as Circle;
            if (other != null)
            {
                if (this.CountArea() > other.CountArea())
                {
                    return 1;
                }
                if (this.CountArea() < other.CountArea())
                {
                    return -1;
                }
                return 0;
            }
            else
            {
                throw new ArgumentException("Parameter is not a Circle!");
            }
        }

        public object Clone()
        {
            return new Circle(center, radius);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}.radius = {this.radius} {this.GetType().Name}.center = {this.center}";
        }
    }
}
