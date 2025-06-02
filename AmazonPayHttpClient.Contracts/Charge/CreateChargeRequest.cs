using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class CreateChargeRequest
{
	public CreateChargeRequest(string chargePermissionId, decimal chargeAmount, Currency currencyCode)
	{
		ChargePermissionId = chargePermissionId;
		ChargeAmount = new Price(chargeAmount, currencyCode);
	}


	/// <summary>
	/// Charge Permission identifier.
	/// </summary>
	[JsonPropertyName("chargePermissionId")]
	public string ChargePermissionId { get; }

	/// <summary>
	/// The total amount that has been captured using this Charge.
	/// </summary>
	[JsonPropertyName("chargeAmount")]
	public Price ChargeAmount { get; }

	/// <summary>
	/// Boolean that indicates whether or not Charge should be captured immediately after a successful authorization.
	/// </summary>
	[JsonPropertyName("captureNow")]
	public bool CaptureNow { get; set; }

	/// <summary>
	/// Description shown on the buyer payment instrument statement, if CaptureNow is set to true. Do not set this value if CaptureNow is set to false.
	/// </summary>
	[JsonPropertyName("softDescriptor")]
	public string? SoftDescriptor { get; set; }

	/// <summary>
	/// Platform ID for each Charge to set by Solution Providers
	/// </summary>
	[JsonPropertyName("platformId")]
	public string? PlatformId { get; set; }

	/// <summary>
	/// Boolean that indicates whether merchant can handle pending response.
	/// </summary>
	[JsonPropertyName("canHandlePendingAuthorization")]
	public bool CanHandlePendingAuthorization { get; set; } = false;

	/// <summary>
	/// Payment service provider (PSP)-provided order information.
	/// </summary>
	[JsonIgnore]
	public ProviderMetadata ProviderMetadata { get; } = new();

	[JsonPropertyName("providerMetadata")]
	public ProviderMetadata? ProviderMetadataRaw => ProviderMetadata.IsEmpty ? null : ProviderMetadata;

	/// <summary>
	/// Merchant-provided order info.
	/// </summary>
	[JsonPropertyName("merchantMetadata")]
	public MerchantMetadata MerchantMetadata { get; } = new();
}