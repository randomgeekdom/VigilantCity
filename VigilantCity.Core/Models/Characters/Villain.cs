using System;
using System.Collections.Generic;
using System.Text;

namespace VigilantCity.Core.Models.Characters
{
    public record Villain : Character
    {
        public VillainStatus Status { get; set; } = VillainStatus.Active;

        override public string ToString()
        {
            if(Alias?.ToLowerInvariant().Trim() == RealName?.ToLowerInvariant().Trim())
            {
                return Alias!;
            }

            return $"{Alias} ({RealName})";
        }
    }
}
