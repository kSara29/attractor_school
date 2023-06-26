using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;


class DateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _dateFormat;

    public DateTimeConverter(string dateFormat)
    {
        _dateFormat = dateFormat;
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string dateStr = reader.GetString();
            return DateTime.ParseExact(dateStr, _dateFormat, CultureInfo.InvariantCulture);
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_dateFormat));
    }
}
