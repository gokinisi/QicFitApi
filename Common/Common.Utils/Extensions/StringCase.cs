using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utils.Extensions
{
    public static class StringCase
    {
        public static string ToCamelCase(string input)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;

            var res = textInfo.ToTitleCase(input);

            return res;
           
        }
    }
}
