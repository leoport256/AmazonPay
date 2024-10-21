
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Frequency Unit for Recurring Charge Permissions
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FrequencyUnit
{
    Year,
    Month,
    Week,
    Day,
    Variable
}