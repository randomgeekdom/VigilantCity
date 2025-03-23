namespace VigilantCity.Core.Models
{
    public record Character : Entity
    {
        public string? Name { get; set; } = "";
        public string? Alias { get; set; } = "";
        public IEnumerable<Power> Powers { get; set; } = [];
        public IEnumerable<Relationship> PersonalRelationships { get; set; } = [];
        public IEnumerable<Relationship> OrganizationRelationships { get; set; } = [];
    }
}