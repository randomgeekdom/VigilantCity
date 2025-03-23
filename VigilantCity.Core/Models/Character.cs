using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models
{
    public record Character : Entity
    {
        [Required]
        public string? Name { get; set; } = "";
        [Required]
        public string? Alias { get; set; } = "";
        [Required]
        public Gender Gender { get; set; }

        public List<Power> Powers { get; set; } = [];
        public List<Relationship> PersonalRelationships { get; set; } = [];
        public List<Relationship> OrganizationRelationships { get; set; } = [];
    }
}