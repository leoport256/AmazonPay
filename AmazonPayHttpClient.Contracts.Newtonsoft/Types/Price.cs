using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class Price
{
	public Price()
	{

	}

	public Price(decimal amount, Currency currencyCode)
	{
		Amount = amount;
		CurrencyCode = currencyCode;
	}

	/// <summary>
	/// Transaction amount.
	/// </summary>
	[JsonProperty("amount")]
	[JsonConverter(typeof(DecimalJsonConverter))]
	public decimal Amount { get; set; }

	/// <summary>
	/// Transaction currency code in ISO 4217 format. Example: USD.
	/// </summary>
	[JsonProperty("currencyCode")]
	public Currency? CurrencyCode { get; set; }

	[JsonIgnore]
	public bool IsEmpty => CurrencyCode is null && Amount == 0;
}