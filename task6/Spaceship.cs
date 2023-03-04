using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Spaceship
    {   //Spaceship (title, yearOfManufacture)
        private string title;
        private int yearOfManufacture;
        public string Title { get { return title; } set { title = value; } }
        public int YearOfManufacture { get { return yearOfManufacture; } set { yearOfManufacture = value; } }

        public Spaceship()
        {
            title = String.Empty;
            yearOfManufacture = default(int);
        }
        public Spaceship(string title, int yearOfManufacture)
        {
            this.title = title;
            this.yearOfManufacture = yearOfManufacture;
        }
        public Spaceship(Spaceship otherSpaceship)
        {
            this.title = otherSpaceship.title;
            this.yearOfManufacture = otherSpaceship.yearOfManufacture;
        }

        public override string ToString()
        {
            return $"{title}\t{yearOfManufacture}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Spaceship otherSpaceship && Title == otherSpaceship.Title
                && YearOfManufacture == otherSpaceship.YearOfManufacture;
        }
    }
}
