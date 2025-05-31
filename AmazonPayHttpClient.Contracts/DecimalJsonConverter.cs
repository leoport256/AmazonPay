using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// JSON Converter class for decimals.
/// </summary>
/// <remarks>
/// Removes fractional part from decimals if not required. Important for Japanse Yen transactions as API may throw an exception otherwise.
/// </remarks>
///
internal sealed class DecimalJsonConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var valueStr = reader.GetString();
        return decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : default;
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        // TODO: This is default behavior of System.Text.Json. This converter does not need. Check it!
        if (value == Math.Truncate(value))
        {
            writer.WriteNumberValue(Convert.ToInt64(value));
        }
        else
        {
            writer.WriteNumberValue(value);
        }
    }
}