using VigilantCity.Core.Models.Organizations;

namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public Guid PlayerCharacterId { get; set; }
        public List<Organization> Organizations { get; set; } = [];
        public List<Character> Characters { get; set; } = [];
    }
}