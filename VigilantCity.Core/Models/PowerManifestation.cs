using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.PowerSets;

namespace VigilantCity.Core.Models
{
    public record PowerManifestation : Entity
    {
        public required Power Power { get; set; }
        public Approach Approach { get; set; }
        public required DifficultyLevel DifficultyLevel { get; set; }
    }
}