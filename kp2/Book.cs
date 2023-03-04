using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{
    internal class Book : Edition
    {
        public string[] authors { get; set; }
        private const int price = 50;

        public Book(string isbn, string title, int yearOfPublishing, string[] authors) : base(isbn, title, yearOfPublishing)
        {
            this.authors = authors;
        }
        public override double Payment()
        {
            return price / (DateTime.Now.Year - yearOfPublishing + 1);
        }
    }
}
