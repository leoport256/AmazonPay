using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class PaymentPreferences
{
	/// <summary>
	/// Amazon Pay-provided description for buyer-selected payment instrument.
	/// </summary>
	[JsonPropertyName("paymentDescriptor")]
	public string? PaymentDescriptor { get; set; }
}