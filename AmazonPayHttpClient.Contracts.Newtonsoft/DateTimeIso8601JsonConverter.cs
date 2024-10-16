using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    public class DateTimeIso8601NullableJsonConverter : JsonConverter<DateTime?>
    {
        private const string AmazonDateTimeFormat = "yyyyMMdd\\THHmmss\\Z";

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(value.Value.ToString(AmazonDateTimeFormat));
            
        }

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? value, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type is JTokenType.Date)
            {
                return token.ToObject<DateTime?>();
            }
            var dateStr = token.ToObject<string>();
            var d = dateStr is not null && DateTime.TryParseExact(dateStr, AmazonDateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AdjustToUniversal, out var parsed)
                ? (DateTime?)DateTime.SpecifyKind(parsed, DateTimeKind.Utc)
                : null;

            return d;
            
        }
    }
    
    
    public class DateTimeIso8601JsonConverter : JsonConverter<DateTime>
    {
        private const string AmazonDateTimeFormat = "yyyyMMdd\\THHmmss\\Z";

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(AmazonDateTimeFormat));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type is JTokenType.Date)
            {
                return token.ToObject<DateTime>();
            }
            var dateStr = token.ToObject<string>();            var d = dateStr is not null && DateTime.TryParseExact(dateStr, AmazonDateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AdjustToUniversal, out var parsed)
                ? DateTime.SpecifyKind(parsed, DateTimeKind.Utc)
                : DateTime.MinValue;

            return d;
            
        }
    }
 
}