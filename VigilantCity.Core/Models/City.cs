namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public Guid PlayerCharacterId { get; set; }
        public List<Character> Characters { get; set; } = [];
    }
}