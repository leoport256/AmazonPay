using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class UpdateChargePermissionRequest
{
	/// <summary>
	/// Merchant-provided order info.
	/// </summary>
	[JsonPropertyName("merchantMetadata")]
	public MerchantMetadata MerchantMetadata { get; } = new();

	/// <summary>
	/// Metadata about how the recurring Charge Permission will be used.
	/// </summary>
	[JsonPropertyName("recurringMetadata")]
	public RecurringMetadata RecurringMetadata { get; } = new();
}