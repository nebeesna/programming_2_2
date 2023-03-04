using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class Tournament : IComparable
    {
        private string title;
        private bool isInternational;
        private int foundationYear;
        public string Title { get; set; }
        public bool IsInternational { get; set; }
        public int FoundationYear { get; set; }
        public Tournament(string title, bool isInternational, int foundationYear)
        {
            this.title = title;
            this.isInternational = isInternational;
            this.foundationYear = foundationYear;
        }
        public override string ToString()
        {
            return $"{title}\t{isInternational}\t{foundationYear}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Tournament otherTournament && Title == otherTournament.Title
                && isInternational == otherTournament.isInternational && FoundationYear == otherTournament.FoundationYear;
        }
        public int CompareTo(object obj)
        {
            Tournament other = obj as Tournament;
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
                throw new NotImplementedException("Parameter is not a Tournament!");
            }
        }
    }
}
