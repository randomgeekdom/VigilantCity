using System.Text.Json;
using System.Text.Json.Serialization;

namespace VigilantCity.Core.Models.PowerSets
{
    public class DifficultyLevelJsonConverter : JsonConverter<DifficultyLevel>
    {
        public override DifficultyLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Expecting a string that corresponds to the DifficultyLevel.Name
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            string name = reader.GetString() ?? throw new JsonException();
            var difficulty = DifficultyLevel.List().FirstOrDefault(dl => dl.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (difficulty == null)
            {
                throw new JsonException($"Unknown DifficultyLevel: {name}");
            }
            return difficulty;
        }

        public override void Write(Utf8JsonWriter writer, DifficultyLevel value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}