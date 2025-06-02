using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Currencies available for Amazon Pay.
/// </summary>
/// <remarks>
/// Specifying a currenty other than the ledger currenc is only supported in the EU region.
/// </remarks>
[JsonConverter(typeof(StringEnumConverter))]
public enum Currency
{
	/// <summary>
	/// Australian Dollar
	/// </summary>
// ReSharper disable once InconsistentNaming
	AUD,

	/// <summary>
	/// British Pound
	/// </summary>
// ReSharper disable once InconsistentNaming
	GBP,

	/// <summary>
	/// Danish Krone
	/// </summary>
// ReSharper disable once InconsistentNaming
	DKK,

	/// <summary>
	/// Euro
	/// </summary>
// ReSharper disable once InconsistentNaming
	EUR,

	/// <summary>
	/// Hong Kong Dollar
	/// </summary>
// ReSharper disable once InconsistentNaming
	HKD,

	/// <summary>
	/// Japanese Yen
	/// </summary>
// ReSharper disable once InconsistentNaming
	JPY,

	/// <summary>
	/// New Zealand Dollar
	/// </summary>
// ReSharper disable once InconsistentNaming
	NZD,

	/// <summary>
	/// Norwegian Krone
	/// </summary>
// ReSharper disable once InconsistentNaming
	NOK,

	/// <summary>
	/// South African Rand
	/// </summary>
// ReSharper disable once InconsistentNaming
	ZAR,

	/// <summary>
	/// Swedish Krone
	/// </summary>
// ReSharper disable once InconsistentNaming
	SEK,

	/// <summary>
	/// Swiss Franc
	/// </summary>
// ReSharper disable once InconsistentNaming
	CHF,

	/// <summary>
	/// United States Dollar
	/// </summary>
// ReSharper disable once InconsistentNaming
	USD
}