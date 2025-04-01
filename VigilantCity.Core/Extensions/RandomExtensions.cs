using System;
using System.Collections.Generic;
using System.Text;

namespace VigilantCity.Core.Extensions
{
    public static class RandomExtensions
    {
        private static readonly Random random = new();
        public static T GetRandom<T>(this Random random)
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }

        public static T GetRandom<T>(this IEnumerable<T> values)
        {
            var valueArray = values.ToArray();
            return valueArray[random.Next(valueArray.Length)];
        }
    }
}
