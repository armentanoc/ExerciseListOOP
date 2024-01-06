
using System.Text.Json;
using System.Text.Json.Serialization;

public class StringToDoubleConverter : JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetDouble();
        }

        if (reader.TokenType == JsonTokenType.String && double.TryParse(reader.GetString(), out double result))
        {
            return result;
        }

        throw new JsonException($"Não foi possível converter {reader.TokenType} para {typeToConvert}");
    }

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
