using VigilantCity.Core.Models.Organizations;

namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public Guid PlayerCharacterId { get; set; }
        public IEnumerable<Organization> Organizations { get; set; } = [];
        public IEnumerable<Character> Characters { get; set; } = [];
    }
}