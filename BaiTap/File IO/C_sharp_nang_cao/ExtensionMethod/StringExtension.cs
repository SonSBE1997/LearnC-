using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class StringExtension
    {
        public static bool IsNumber(this string input)
        {
            int output = 0;
            var value = int.TryParse(input, out output);
            return value;
        }

        public static bool IsMinSize(this string input, int minSize)
        {
            return input != null && input.Length >= minSize;
        }
    }
}
