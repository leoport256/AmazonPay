using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CheckoutSession
{
	/// <summary>
	/// Login with Amazon client ID. Do not use the application ID.
	/// </summary>
	[JsonProperty("storeId")]
	public string? StoreId { get; set; }

	/// <summary>
	/// Checkout Session identifer.
	/// </summary>
	[JsonProperty("checkoutSessionId")]
	public required string CheckoutSessionId { get; set; }

	/// <summary>
	/// URLs associated to the Checkout Session used for completing checkout
	/// </summary>
	[JsonProperty("webCheckoutDetails")]
	public WebCheckoutDetails? WebCheckoutDetails { get; set; }

	/// <summary>
	/// Amazon Pay integration type.
	/// </summary>
	[JsonProperty("productType")]
	public string? ProductType { get; set; }

	/// <summary>
	/// Payment details specified by the merchant, such as the amount and method for charging the buyer
	/// </summary>
	[JsonProperty("paymentDetails")]
	public PaymentDetails? PaymentDetails { get; set; }

	/// <summary>
	/// Merchant-provided order info.
	/// </summary>
	[JsonProperty("merchantMetadata")]
	public MerchantMetadata? MerchantMetadata { get; set; }

	/// <summary>
	/// Details about the buyer, such as their unique identifer, name, and email.
	/// </summary>
	[JsonProperty("buyer")]
	public Buyer? Buyer { get; set; }

	/// <summary>
	/// State of the Checkout Session object.
	/// </summary>
	[JsonProperty("statusDetails")]
	public StatusDetails? StatusDetails { get; set; }

	/// <summary>
	/// Supplementary data.
	/// </summary>
	[JsonProperty("supplementaryData")]
	public string? SupplementaryData { get; set; }

	/// <summary>
	/// Merchant identifer of the Solution Provider (SP) - also known as ecommerce provider.
	/// </summary>
	[JsonProperty("platformId")]
	public string? PlatformId { get; set; }

	/// <summary>
	/// Payment service provider (PSP)-provided order information.
	/// </summary>
	[JsonProperty("providerMetadata")]
	public ProviderMetadata? ProviderMetadata { get; set; }

	/// <summary>
	/// Shipping address selected by the buyer.
	/// </summary>
	[JsonProperty("shippingAddress")]
	public Address? ShippingAddress { get; set; }

	/// <summary>
	/// Billing address for buyer-selected payment instrument. Billing address is only available in EU or for PayOnly product type.
	/// </summary>
	[JsonProperty("billingAddress")]
	public Address? BillingAddress { get; set; }

	/// <summary>
	/// List of payment instruments selected by the buyer.
	/// </summary>
	[JsonProperty("paymentPreferences")]
	public List<PaymentPreferences>? PaymentPreferences { get; set; }

	/// <summary>
	/// Constraints that must be addressed to complete Amazon Pay checkout.
	/// </summary>
	[JsonProperty("constraints")]
	public List<Constraint>? Constraints { get; set; }

	/// <summary>
	/// Universal Time Coordinated (UTC) date and time when the Checkout Session was created in ISO 8601 format.
	/// </summary>
	[JsonProperty("creationTimestamp")]
	public DateTime CreationTimestamp { get; set; }

	/// <summary>
	/// UTC date and time when the Charge will expire in ISO 8601 format.
	/// </summary>
	/// <remarks>The Charge Permission will expire 180 days after it's confirmed</remarks>
	[JsonProperty("expirationTimestamp")]
	public DateTime? ExpirationTimestamp { get; set; }

	/// <summary>
	/// Charge permission identifier returned after Checkout Session is complete.
	/// </summary>
	[JsonProperty("chargePermissionId")]
	public string? ChargePermissionId { get; set; }

	/// <summary>
	/// Charge identifier returned after Checkout Session is complete.
	/// </summary>
	[JsonProperty("chargeId")]
	public string? ChargeId { get; set; }

	/// <summary>
	/// Specify shipping restrictions to prevent buyers from selecting unsupported addresses from their Amazon address book.
	/// </summary>
	[JsonProperty("deliverySpecifications")]
	public DeliverySpecifications? DeliverySpecifications { get; set; }

	/// <summary>
	/// The environment of the Amazon Pay API (live or sandbox).
	/// </summary>
	[JsonProperty("releaseEnvironment")]
	public string ReleaseEnvironment { get; set; } = "sandbox";

	/// <summary>
	/// Configure OneTime or Recurring payment chargePermissionType
	/// </summary>
	[JsonProperty("chargePermissionType")]
	public ChargePermissionType? ChargePermissionType { get; set; }

	/// <summary>
	/// Metadata about how the recurring Charge Permission will be used. Amazon Pay only uses this information to calculate the Charge Permission expiration date and in buyer communication.
	/// </summary>
	[JsonProperty("recurringMetadata")]
	public RecurringMetadata? RecurringMetadata { get; set; }
}