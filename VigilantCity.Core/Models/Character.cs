using System.ComponentModel.DataAnnotations;
using VigilantCity.Core.Models.Enumerations;

namespace VigilantCity.Core.Models
{
    public record Character : Entity
    {
        [Required]
        public string? Name { get; set; } = "";
        [Required]
        public string? Alias { get; set; } = "";

        public List<Power> Powers { get; set; } = [];
        public List<Relationship> PersonalRelationships { get; set; } = [];

        public Dictionary<Skill, int> Skills = [];
    }
}