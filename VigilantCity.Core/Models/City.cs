namespace VigilantCity.Core.Models
{
    public record City : Entity
    {
        public required HeroOrganization Organization { get; set; }
        public IEnumerable<Hero> Heroes { get; set; } = [];
    }
}