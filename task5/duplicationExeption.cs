using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class duplicationExeption : Exception
    {
        public duplicationExeption(string msg) : base(msg) { }
        public duplicationExeption(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
