using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Attributes
{
    public class CustomDateOnlyConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && reader.GetString() is string dateString)
            {
                if (DateTime.TryParseExact(dateString, DateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate.Date;
                }
            }

            throw new JsonException($"Data em formato inválido. Format esperado: {DateFormat}.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }
    }
}
