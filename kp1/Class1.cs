using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp1
{
    static class NewExtension
    {
        public static bool ContainsPunctuationSymbols(this System.String str)
        {
            bool result = false;
            if (str.Contains(",") || str.Contains(".") || str.Contains("-") || str.Contains("!") || str.Contains("?"))
            {
                result = true;
            }
            return result;
        }
    }
}
