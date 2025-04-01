using System.Text.Json.Serialization;

namespace VigilantCity.Core.Models.PowerSets
{
    [JsonConverter(typeof(DifficultyLevelJsonConverter))]
    public sealed class DifficultyLevel
    {
        public string Name { get; }
        public int Roll { get; }
        public int EnergyCost { get; }

        private DifficultyLevel(string name, int roll, int energyCost)
        {
            Name = name;
            Roll = roll;
            EnergyCost = energyCost;
        }

        public static readonly DifficultyLevel Easy = new(nameof(Easy), 5, 1);
        public static readonly DifficultyLevel Average = new(nameof(Average), 10, 4);
        public static readonly DifficultyLevel Difficult = new(nameof(Difficult), 15, 8);
        public static readonly DifficultyLevel Backbreaking = new(nameof(Backbreaking), 20, 12);

        public override string ToString() => Name;

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
    }
}