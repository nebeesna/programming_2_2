using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class FootballTeam : IComparable 
    {
        private string title;
        private string city;
        private int foundationYear;
        public string Title{get; set;}
        public string City {get; set;}
        public int FoundationYear {get; set;}
        public FootballTeam(string title, string city, int foundationYear)
        {
            this.title = title;
            this.city = city;   
            this.foundationYear = foundationYear;   
        }
        public override string ToString()
        {
            return $"{title}\t{city}\t{foundationYear}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is FootballTeam otherTeam && Title == otherTeam.Title 
                && City == otherTeam.City && FoundationYear == otherTeam.FoundationYear;
        }
        public int CompareTo(object obj)
        {
            FootballTeam other = obj as FootballTeam;
            if (other != null)
            {
                if (this.FoundationYear > other.FoundationYear)
                {
                    return 1;
                }
                else if (this.FoundationYear < other.FoundationYear)
                {
                    return -1;
                }
                return 0;
            }
            else
            {
                throw new NotImplementedException("Parameter is not a FootballTeam!");
            }
        }
    }
}
