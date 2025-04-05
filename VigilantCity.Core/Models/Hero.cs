using System.ComponentModel.DataAnnotations;
using VigilantCity.Core.Models.SmartEnums;

namespace VigilantCity.Core.Models
{
    public partial record Hero : Entity
    {
        [Required]
        public string? RealName { get; set; } = "";
        [Required]
        public string? Alias { get; set; } = "";

        public List<Power> Powers { get; set; } = [];
        public List<Relationship> PersonalRelationships { get; set; } = [];
        public List<PowerManifestation> PowerManifestations { get; set; } = [];

        public int Reputation { get; set; }

        override public string ToString() => $"{Alias} ({RealName})";
    }
}