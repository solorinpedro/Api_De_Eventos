using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventoApi.Models
{ 
    public class ConvertirFecha : JsonConverter<DateTime>
    {
        private const string FormatoFecha = "dd/MM/yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && DateTime.TryParseExact(reader.GetString(), FormatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out var fecha))
            {
                return fecha;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(FormatoFecha, CultureInfo.InvariantCulture));
        }
    }
}
