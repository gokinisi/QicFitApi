
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Common.Entities.Helpers
{
    public class EnumHelper<TEnum> where TEnum : struct, IConvertible
    {
        public static IEnumerable<TEnum> GetValuesContains(string str)
        {
            return typeof(TEnum).IsEnum
                ? Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .Where(s => s.ToString(CultureInfo.InvariantCulture).ToLower().Contains(str.ToLower()))
                : Enumerable.Empty<TEnum>();
        }
    }
}