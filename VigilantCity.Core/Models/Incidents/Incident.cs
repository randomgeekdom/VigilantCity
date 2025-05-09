﻿using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.PowerSets;
using VigilantCity.Core.Models.SmartEnums;

namespace VigilantCity.Core.Models.Incidents
{
    public record Incident : Entity
    {
        public IncidentType Type { get; set; }
        public string Description { get; set; }
        public District District { get; set; }
        public int TimeToResolve { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public Dictionary<Approach, int> ApproachModifiers { get; set; } = [];
        
        public Incident(string description, IncidentType type, District district, DifficultyLevel difficultyLevel, int timeToResolve, Dictionary<Approach, int> approachModifiers)
        {
            this.Description = description;
            this.Type = type;
            this.District = district;
            this.DifficultyLevel = difficultyLevel;
            this.TimeToResolve = timeToResolve;
            this.ApproachModifiers = approachModifiers;
        }

        public string GetFullDescription() 
        {
            return $"{Type.GetDisplayName()} in {District.GetDisplayName()}";
        }
    }
}