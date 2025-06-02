
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Ledger Currencies available for Amazon Pay.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum LedgerCurrency
{
	/// <summary>
	/// British Pound
	/// </summary>
// ReSharper disable once InconsistentNaming
	GBP,

	/// <summary>
	/// Euro
	/// </summary>
// ReSharper disable once InconsistentNaming
	EUR,

	/// <summary>
	/// Japanese Yen
	/// </summary>
// ReSharper disable once InconsistentNaming
	JPY,

	/// <summary>
	/// United States Dollar
	/// </summary>
// ReSharper disable once InconsistentNaming
	USD
}