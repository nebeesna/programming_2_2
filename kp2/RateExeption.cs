using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{
    internal class RateExeption : Exception
    {
        public RateExeption(string msg) : base(msg) { }
        public RateExeption(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
