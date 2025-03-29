using VigilantCity.Core.Models.Incidents;

namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public required Character PlayerCharacter { get; set; }
        public List<Character> Characters { get; set; } = [];
        public List<Incident> Incidents { get; set; } = [];
    }
}