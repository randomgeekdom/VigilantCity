using System.Text.Json.Serialization;

namespace VigilantCity.Core.Models.PowerSets
{
    [JsonConverter(typeof(DifficultyLevelJsonConverter))]
    public sealed class DifficultyLevel
    {
        public static readonly DifficultyLevel Average = new(nameof(Average), 10);

        public static readonly DifficultyLevel Backbreaking = new(nameof(Backbreaking), 20);

        public static readonly DifficultyLevel Difficult = new(nameof(Difficult), 15);

        public static readonly DifficultyLevel Easy = new(nameof(Easy), 5);

        private DifficultyLevel(string name, int roll)
        {
            Name = name;
            Roll = roll;
        }

        public string Name { get; }

        public int Roll { get; }

        public static IEnumerable<DifficultyLevel> List()
        {
            return
            [
                Easy,
                Average,
                Difficult,
                Backbreaking
            ];
        }

        public override bool Equals(object? obj)
        {
            if (obj is DifficultyLevel other)
            {
                return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


        public int GetModifier() => Roll / 5;

        public override string ToString() => Name;
    }
}