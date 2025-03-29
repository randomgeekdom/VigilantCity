using System;
using System.Collections.Generic;
using System.Text;
using VigilantCity.Core.Models.Incidents;

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

        public static string GetIncidentText(this IncidentType value) 
        {
            return value switch
            {
                IncidentType.Rampage => "Someone is going on a rampage",
                IncidentType.Robbery => "A robbery is in progress",
                IncidentType.Kidnapping => "Someone has been kidnapped",
                IncidentType.MurderInvestigation => "Someone has been murdered.  No suspects have been identified",
                _ => "An incident is in progress",
            };
        }

        public static int GetIncidentTimeToResolve(this IncidentType value)
        {
            Random random = new();
            return value switch
            {
                IncidentType.Kidnapping => random.Next(1, 5),
                IncidentType.MurderInvestigation => random.Next(1, 16),
                _ => 1,
            };
        }
    }
}