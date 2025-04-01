using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.PowerSets;

namespace VigilantCity.Core.Models.SmartEnums
{
    public sealed class PowerManifestation(string name, Approach relatedApproach, DifficultyLevel difficultyLevel)
    {
        public string Name { get; } = name;
        public Approach RelatedApproach { get; } = relatedApproach;
        public DifficultyLevel DifficultyLevel { get; } = difficultyLevel;
    }
}