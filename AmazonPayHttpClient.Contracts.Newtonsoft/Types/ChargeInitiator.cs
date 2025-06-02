using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Represents who initiated the payment.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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