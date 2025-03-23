namespace VigilantCity.Core.Models
{
    public record Power : Entity
    {
        public PowerSet PowerSet { get; set; }
        public PowerOrigin PowerOrigins { get; set; }
    }
}