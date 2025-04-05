using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.PowerSets;

namespace VigilantCity.Core.Models.SmartEnums
{
    public record PowerManifestation(Approach Approach, PowerOrigin PowerOrigin, PowerSet PowerSet, DifficultyLevel DifficultyLevel) : Entity
    {
    }
}