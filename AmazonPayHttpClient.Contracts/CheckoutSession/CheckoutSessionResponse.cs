using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class CheckoutSessionResponse
{
    /// <summary>
    /// Login with Amazon client ID. Do not use the application ID.
    /// </summary>
    [JsonPropertyName("storeId")]
    public string? StoreId { get; set; }

    /// <summary>
    /// Checkout Session identifer.
    /// </summary>
    [JsonPropertyName("checkoutSessionId")]
    public string CheckoutSessionId { get; set; } = null!;

    /// <summary>
    /// URLs associated to the Checkout Session used for completing checkout
    /// </summary>
    [JsonPropertyName("webCheckoutDetails")]
    public WebCheckoutDetails? WebCheckoutDetails { get;  set; }

    /// <summary>
    /// Amazon Pay integration type.
    /// </summary>
    [JsonPropertyName("productType")]
    public string? ProductType { get;  set; }

    /// <summary>
    /// Payment details specified by the merchant, such as the amount and method for charging the buyer
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PaymentDetails? PaymentDetails { get;  set; }

    /// <summary>
    /// Merchant-provided order info.
    /// </summary>
    [JsonPropertyName("merchantMetadata")]
    public MerchantMetadata? MerchantMetadata { get;  set; }

    /// <summary>
    /// Details about the buyer, such as their unique identifer, name, and email.
    /// </summary>
    [JsonPropertyName("buyer")]
    public Buyer? Buyer { get;  set; }

    /// <summary>
    /// State of the Checkout Session object.
    /// </summary>
    [JsonPropertyName("statusDetails")]
    public StatusDetails StatusDetails { get;  set; }

    /// <summary>
    /// Supplementary data.
    /// </summary>
    [JsonPropertyName("supplementaryData")]
    public string? SupplementaryData { get; set; }

    /// <summary>
    /// Merchant identifer of the Solution Provider (SP) - also known as ecommerce provider.
    /// </summary>
    [JsonPropertyName("platformId")]
    public string PlatformId { get; set; }

    /// <summary>
    /// Payment service provider (PSP)-provided order information.
    /// </summary>
    [JsonPropertyName("providerMetadata")]
    public ProviderMetadata? ProviderMetadata { get;  set; }

    /// <summary>
    /// Shipping address selected by the buyer.
    /// </summary>
    [JsonPropertyName("shippingAddress")]
    public Address? ShippingAddress { get;  set; }

    /// <summary>
    /// Billing address for buyer-selected payment instrument. Billing address is only available in EU or for PayOnly product type.
    /// </summary>
    [JsonPropertyName( "billingAddress")]
    public Address? BillingAddress { get;  set; }

    /// <summary>
    /// List of payment instruments selected by the buyer.
    /// </summary>
    [JsonPropertyName("paymentPreferences")]
    public List<PaymentPreferences>? PaymentPreferences { get;  set; }

    /// <summary>
    /// Constraints that must be addressed to complete Amazon Pay checkout.
    /// </summary>
    [JsonPropertyName("constraints")]
    public List<Constraint>? Constraints { get;  set; }

    /// <summary>
    /// Universal Time Coordinated (UTC) date and time when the Checkout Session was created in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("creationTimestamp")]
    public DateTime CreationTimestamp { get;  set; }

    /// <summary>
    /// UTC date and time when the Charge will expire in ISO 8601 format.
    /// </summary>
    /// <remarks>The Charge Permission will expire 180 days after it's confirmed</remarks>
    [JsonPropertyName("expirationTimestamp")]
    public DateTime? ExpirationTimestamp { get;  set; }

    /// <summary>
    /// Charge permission identifier returned after Checkout Session is complete.
    /// </summary>
    [JsonPropertyName("chargePermissionId")]
    public string? ChargePermissionId { get;  set; }

    /// <summary>
    /// Charge identifier returned after Checkout Session is complete.
    /// </summary>
    [JsonPropertyName("chargeId")]
    public string? ChargeId { get;  set; }

    /// <summary>
    /// Specify shipping restrictions to prevent buyers from selecting unsupported addresses from their Amazon address book.
    /// </summary>
    [JsonPropertyName("deliverySpecifications")]
    public DeliverySpecifications? DeliverySpecifications { get;  set; }

    /// <summary>
    /// The environment of the Amazon Pay API (live or sandbox).
    /// </summary>
    [JsonPropertyName("releaseEnvironment")]
    public string ReleaseEnvironment { get;  set; }

    /// <summary>
    /// Configure OneTime or Recurring payment chargePermissionType
    /// </summary>
    [JsonPropertyName("chargePermissionType")]
    public ChargePermissionType? ChargePermissionType { get;  set; }

    /// <summary>
    /// Metadata about how the recurring Charge Permission will be used. Amazon Pay only uses this information to calculate the Charge Permission expiration date and in buyer communication.
    /// </summary>
    [JsonPropertyName("recurringMetadata")]
    public RecurringMetadata? RecurringMetadata { get;  set; }
}