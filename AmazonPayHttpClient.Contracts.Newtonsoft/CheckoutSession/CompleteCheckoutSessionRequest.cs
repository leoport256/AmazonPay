using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CompleteCheckoutSessionRequest
{
	public CompleteCheckoutSessionRequest(decimal amount, Currency currency)
	{
		ChargeAmount = new Price(amount, currency);
	}

	public CompleteCheckoutSessionRequest()
	{
		ChargeAmount = new Price();
	}

	/// <summary>
	/// The total transaction amount that this CheckoutSession is associated with.
	/// </summary>
	[JsonIgnore]
	public Price ChargeAmount { get; }

	[JsonProperty("chargeAmount")]
	public Price? ChargeAmountRaw => ChargeAmount.IsEmpty ? null : ChargeAmount;


	/// <summary>
	/// Total order amount, only use this parameter if you need to process additional payments after checkout.
	/// </summary>
	[JsonIgnore]
	public Price TotalOrderAmount { get; } = new();

	[JsonProperty("totalOrderAmount")]
	public Price? TotalOrderAmountRaw => TotalOrderAmount.IsEmpty ? null : TotalOrderAmount;
}