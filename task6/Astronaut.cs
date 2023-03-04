using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{   //Astronaut(name, surname, birthYear)
    internal class Astronaut
    {
        private string name;
        private string surname;
        private int birthYear;
        public string Name { get { return name; } set { name = value; } }   
        public string Surname { get { return surname; } set { surname = value; } }
        public int BirthYear { get { return birthYear; } set { birthYear = value; } }

        public Astronaut()
        {
            name = String.Empty;
            surname = String.Empty;
            birthYear = default(int);
        }
        public Astronaut(string name, string surname, int birthYear)
        {
            this.name = name;
            this.surname = surname;
            this.birthYear = birthYear;
        }

        public override string ToString()
        {
            return $"{name}\t{surname}\t{birthYear}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Astronaut otherAstronaut && Name == otherAstronaut.Name
                && Surname == otherAstronaut.Surname && BirthYear == otherAstronaut.BirthYear;
        }


    }
}
