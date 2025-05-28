using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Type of Business.
/// </summary>
// [JsonConverter(typeof(StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BusinessType
{
	/// <summary>
	/// Corporate Entity
	/// </summary>
	CORPORATE,

	/// <summary>
	/// Indiviual Entity/ Sole Propeitor
	/// </summary>
	INDIVIDUAL
}