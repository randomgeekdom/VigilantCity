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

        public static bool NextBool(this Random random, int percent = 50)
        {
            return random.Next(0, 100) < percent;
        }

        public static T GetRandom<T>(this IEnumerable<T> values)
        {
            var valueArray = values.ToArray();
            return valueArray[random.Next(valueArray.Length)];
        }
    }
}
