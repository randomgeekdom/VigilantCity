using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Characters
{
    public partial record Hero : Character
    {
        public List<Relationship> PersonalRelationships { get; set; } = [];

        public int Reputation { get; set; }

        override public string ToString() => $"{Alias} ({RealName})";
    }
}