using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// JSON Converter class for decimals.
/// </summary>
/// <remarks>
/// Removes fractional part from decimals if not required. Important for Japanse Yen transactions as API may throw an exception otherwise.
/// </remarks>
///
internal class DecimalJsonConverter : JsonConverter<decimal>
{
    public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
    {
        if (value == Math.Truncate(value))
        {
            writer.WriteValue(Convert.ToInt64(value));
        }
        else
        {
            writer.WriteValue(value);
        }        
    }

    public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        if (token.Type is JTokenType.Float or JTokenType.Integer)
        {
            return token.ToObject<decimal>();
        }

        var tokenAsString = token.ToObject<string>();
        return decimal.TryParse(tokenAsString, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : default;
    }
}
    
internal class DecimalJsonConverter1 : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {

        {
            writer.WriteValue(value);
        }        
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        var valueStr = existingValue as string;
        return decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : default;
    }

    public override bool CanConvert(Type objectType)
    {
        return true;
    }
}