using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{
    internal abstract class Edition
    {
        public string isbn { get; set; }
        public string title { get; set; }
        public int yearOfPublishing { get; set; }
        public Edition(string isbn, string title, int yearOfPublishing)
        {
            this.isbn = isbn;
            this.title = title; 
            this.yearOfPublishing = yearOfPublishing;
        }
        abstract public double Payment();
        
    }
}
