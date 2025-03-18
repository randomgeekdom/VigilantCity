namespace VigilantCity.Core.Models
{
    public record Hero : Entity
    {
        public required string Name { get; set; }
        public required string Alias { get; set; }
        public IEnumerable<PowerSet> PowerSets { get; set; } = [];
        public PowerOrigin PowerOrigin { get; set; }
    }
}