using System;
using System.Collections.Generic;
using System.Text;

namespace VigilantCity.Core.Extensions
{
    public static class RandomExtensions
    {
        public static T GetRandom<T>(this Random random)
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }
    }
}
