﻿using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.SmartEnums;

namespace VigilantCity.Core.Models
{
    public record Power : Entity
    {
        public PowerSet? PowerSet { get; set; }
        public PowerOrigin PowerOrigin { get; set; }
    }
}