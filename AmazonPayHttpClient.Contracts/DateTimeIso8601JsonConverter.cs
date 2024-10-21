using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class DateTimeIso8601NullableJsonConverter : JsonConverter<DateTime?>
{
    private const string AmazonDateTimeFormat = "yyyyMMdd\\THHmmss\\Z";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateStr = reader.GetString();
        var d = dateStr is not null && DateTime.TryParseExact(dateStr, AmazonDateTimeFormat,
            CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AdjustToUniversal, out var parsed)
            ? (DateTime?)DateTime.SpecifyKind(parsed, DateTimeKind.Utc)
            : null;

        return d;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }
        writer.WriteStringValue(value.Value.ToString(AmazonDateTimeFormat));
    }
}
    
    
public class DateTimeIso8601JsonConverter : JsonConverter<DateTime>
{
    public override bool HandleNull => true;
        
    private const string AmazonDateTimeFormat = "yyyyMMdd\\THHmmss\\Z";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateStr = reader.GetString();
        var d = dateStr is not null && DateTime.TryParseExact(dateStr, AmazonDateTimeFormat,
            CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AdjustToUniversal, out var parsed)
            ? DateTime.SpecifyKind(parsed, DateTimeKind.Utc)
            : DateTime.MinValue;

        return d;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(AmazonDateTimeFormat));
    }
}