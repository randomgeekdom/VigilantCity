using System.Text.Json;
using System.Text.Json.Serialization;
using VigilantCity.Core.Models.SmartEnums;

namespace VigilantCity.Core.Models.PowerSets
{
    public class PowerSetJsonConverter : JsonConverter<PowerSet>
    {
        public override PowerSet Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            var name = reader.GetString();
            foreach (var powerSet in PowerSet.List())
            {
                if (string.Equals(powerSet.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return powerSet;
                }
            }
            throw new JsonException($"Unknown PowerSet: {name}");
        }

        public override void Write(Utf8JsonWriter writer, PowerSet value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}