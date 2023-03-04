using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Triangle : IFigure, IComparable, ICloneable
    {
        private double a;
        private double b;
        private double c;
        public Triangle()
        {
            a = 0;
            b = 0;
            c = 0;
        }
        public Triangle(double firstSide, double secondSide,double thirdSide)
        {
            if (firstSide + secondSide > thirdSide || secondSide + thirdSide > firstSide || firstSide + thirdSide > secondSide)
            {
                a = firstSide;
                b = secondSide;
                c = thirdSide;
            }
            else
            {
                throw new Exception("this triangle doesn't exist!");
            }
        }
        public double CountArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public int CompareTo(object obj)
        {
            Triangle other = obj as Triangle;
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
                throw new ArgumentException("Parameter is not a Triangle!");
            }
        }
        public object Clone()
        {
            return new Triangle(a, b, c);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}.a = {this.a} {this.GetType().Name}.b = {this.b} {this.GetType().Name}.c = {this.c}";
        }
    }
}
