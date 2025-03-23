namespace VigilantCity.Core.Models
{
    public record Relationship : Entity
    {
        public Guid RelatedId { get; set; }
        public byte Description { get; set; }
    }
}