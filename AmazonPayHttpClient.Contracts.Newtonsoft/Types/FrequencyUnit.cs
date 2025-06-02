
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Frequency Unit for Recurring Charge Permissions
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum FrequencyUnit
{
	Year,
	Month,
	Week,
	Day,
	Variable
}