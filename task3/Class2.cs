using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Square : IFigure, IComparable, ICloneable
    {
        private double side;
        public Square()
        {
            side = 0; 
        }
        public Square(double a)
        {
            side = a; 
        }
        public int CompareTo(object obj)
        {
            Square other = obj as Square;
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
                throw new ArgumentException("Parameter is not a Square!");
            }
        }

        public double CountArea()
        {
            return side * side;
        }
        public object Clone()
        {
            return new Square(side);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}.side = {this.side}";
        }
    }
}
