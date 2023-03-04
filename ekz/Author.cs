using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekz
{
    /*Автор характеризується iдентифiкацiйним номером автора, прiзвищем i
країною проживання*/
    [Serializable]
    public class Author
    {
        public int Id  { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public Author()
        {
            Id = 0;
            LastName = String.Empty;
            FirstName = String.Empty;
            Country = String.Empty;
        }
        public Author(int id, string lastName, string firstName, string country)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Country = country;
        }
        public override string ToString()
        {
            return $"{Id}\t{LastName}\t{FirstName}\t{Country}";
        }
    }
}
