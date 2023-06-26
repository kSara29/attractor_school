using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
using System;

namespace Exam_4
{
    class DateConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "dd.MM.yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return DateTime.ParseExact(reader.GetString(), DateFormat, null);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }
    }

}