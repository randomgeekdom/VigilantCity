using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Characters
{
    public abstract record Character : Entity
    {
        [Required]
        public string? RealName { get; set; } = "";
        [Required]
        public string? Alias { get; set; } = "";

        public int PowerLevel { get; set; } = 1;

        public List<Power> Powers { get; set; } = [];
        public List<PowerManifestation> PowerManifestations { get; set; } = [];
    }
}