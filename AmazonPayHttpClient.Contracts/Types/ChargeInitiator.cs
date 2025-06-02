using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Represents who initiated the payment.
/// </summary>
//[JsonConverter(typeof(StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChargeInitiator
{
// ReSharper disable once InconsistentNaming
	CITU,

// ReSharper disable once InconsistentNaming
	MITU,

// ReSharper disable once InconsistentNaming
	CITR,

// ReSharper disable once InconsistentNaming
	MITR
}