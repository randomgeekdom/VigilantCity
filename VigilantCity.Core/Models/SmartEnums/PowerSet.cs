using System.Text.Json.Serialization;
using VigilantCity.Core.Extensions;
using VigilantCity.Core.Models.PowerSets;

namespace VigilantCity.Core.Models.SmartEnums
{
    [JsonConverter(typeof(PowerSetJsonConverter))]
    public sealed class PowerSet
    {

        public static readonly PowerSet ArmoredBody = new("ArmoredBody", "Armored Body", ["Armor", "Steel"]);

        public static readonly PowerSet CombatMaster = new("CombatMaster", "Combat Mastery", ["Combat", "Fight"]);

        public static readonly PowerSet EnergyManipulation = new(nameof(EnergyManipulation), "Energy Manipulation", ["Energy", "Laser", "Light"]);

        public static readonly PowerSet Flight = new(nameof(Flight), "Flight", ["Flying", "Glide", "Kite"]);

        public static readonly PowerSet Invisibility = new(nameof(Invisibility), "Invisibility", ["Clear", "Glass", "Invisible", "Transparent"]);

        public static readonly PowerSet Precognition = new(nameof(Precognition), "Precognition", ["Precognition", "Predict", "Psychic"]);

        public static readonly PowerSet Shapeshifting = new(nameof(Shapeshifting), "Shapeshifting", ["Animal", "Beast", "Creature"]);

        public static readonly PowerSet SizeManipulation = new(nameof(SizeManipulation), "Size Manipulation", ["Big", "Giant", "Tiny"]);

        public static readonly PowerSet SuperSenses = new(nameof(SuperSenses), "Super Senses", ["Alert", "Sense"]);

        public static readonly PowerSet SuperSpeed = new(nameof(SuperSpeed), "Super Speed", ["Fast", "Movement", "Quick", "Rapid"]);

        public static readonly PowerSet SuperStrength = new(nameof(SuperStrength), "Super Strength", ["Might", "Mighty", "Power", "Strong"]);

        public static readonly PowerSet Technopathy = new(nameof(Technopathy), "Technopathy", ["Tech", "Techno"]);

        public static readonly PowerSet Telekinesis = new(nameof(Telekinesis), "Telekinesis", ["Mind", "Move"]);

        public static readonly PowerSet Telepathy = new(nameof(Telepathy), "Telepathy", ["Mind", "Thought"]);

        public static readonly PowerSet Teleportation = new(nameof(Teleportation), "Teleportation", ["Blink", "Teleport", "Warp"]);

        public static readonly PowerSet TimeManipulation = new(nameof(TimeManipulation), "Time Manipulation", ["Chrono", "Time"]);

        private PowerSet(string name, string? displayName, List<string> prefixes)
        {
            Name = name;
            DisplayName = displayName ?? name;
            Prefixes = prefixes;
        }

        public string DisplayName { get; }
        public List<string> Prefixes { get; }
        public string Name { get; }

        public static IEnumerable<PowerSet> List()
        {
            return
            [
                Flight,
                SuperStrength,
                SuperSpeed,
                Telekinesis,
                Telepathy,
                Invisibility,
                Shapeshifting,
                TimeManipulation,
                EnergyManipulation,
                SizeManipulation,
                Technopathy,
                Teleportation,
                Precognition,
                SuperSenses,
                CombatMaster,
                ArmoredBody
            ];
        }

        public override bool Equals(object? obj)
        {
            if (obj is PowerSet other)
            {
                return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => DisplayName;

        public string GetName()
        {
            List<string> suffixes = ["Man", "Woman", "Girl", "Boy", "Child", "Kid", "Person", "Master", "Mistress", "Knight", "Warrior", "Lord", "Lady"];
            return $"{this.Prefixes.GetRandom()} {suffixes.GetRandom()}";
        }
    }
}