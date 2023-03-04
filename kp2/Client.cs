using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{
    internal class Client
    {
        public string lastName { get; set; }
        public List<Edition> editions { get; set; }
        public Client(string lastName)
        {
            this.lastName = lastName;
        }
        public void Borrow(Edition e)
        {
            editions.Add(e);
        }
    }
}
