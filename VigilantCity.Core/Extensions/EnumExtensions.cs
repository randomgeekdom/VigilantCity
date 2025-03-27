using System;
using System.Collections.Generic;
using System.Text;

namespace VigilantCity.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            System.ComponentModel.DataAnnotations.DisplayAttribute? attribute = (System.ComponentModel.DataAnnotations.DisplayAttribute)field.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false).FirstOrDefault();
            return attribute?.Description ?? value.ToString();
        }

        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (System.ComponentModel.DataAnnotations.DisplayAttribute)field.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false).FirstOrDefault();
            return attribute?.Name ?? value.ToString();
        }

        public static T GetRandom<T>(this Enum value)
        {
            var values = Enum.GetValues(typeof(T));
            var random = new Random();
            return (T)values.GetValue(random.Next(values.Length));
        }
    }
}