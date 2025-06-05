using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Type of Business.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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