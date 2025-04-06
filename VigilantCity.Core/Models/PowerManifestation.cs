using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.PowerSets;
using VigilantCity.Core.Models.SmartEnums;

namespace VigilantCity.Core.Models
{
    public record PowerManifestation(Approach Approach, PowerOrigin PowerOrigin, PowerSet PowerSet, DifficultyLevel DifficultyLevel) : Entity
    {
        public string? Name { get; set; }
    }
}