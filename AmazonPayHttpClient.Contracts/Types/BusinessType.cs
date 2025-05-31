using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

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
	// ReSharper disable once InconsistentNaming
	CORPORATE,

	/// <summary>
	/// Indiviual Entity/ Sole Propeitor
	/// </summary>
	// ReSharper disable once InconsistentNaming
	INDIVIDUAL
}