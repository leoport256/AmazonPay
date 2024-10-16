using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class ChargePermissionResponse
    {
        /// <summary>
        /// Charge Permission identifer.
        /// </summary>
        [JsonPropertyName("chargePermissionId")]
        public string ChargePermissionId { get; set; } = null!;

        /// <summary>
        /// Limits that apply to this ChargePermission.
        /// </summary>
        [JsonPropertyName("limits")]
        public Limits? Limits { get;  set; }

        /// <summary>
        /// The environment of the Amazon Pay API (live or sandbox).
        /// </summary>
        [JsonPropertyName("releaseEnvironment")]
        public string? ReleaseEnvironment { get;  set; }

        /// <summary>
        /// Details about the buyer, such as their unique identifer, name, and email.
        /// </summary>
        [JsonPropertyName("buyer")]
        public Buyer? Buyer { get;  set; }

        /// <summary>
        /// Shipping address selected by the buyer.
        /// </summary>
        [JsonPropertyName("shippingAddress")]
        public Address? ShippingAddress { get;  set; }

        /// <summary>
        /// Billing address for buyer-selected payment instrument. Billing address is only available in EU or for PayOnly product type.
        /// </summary>
        [JsonPropertyName("billingAddress")]
        public Address? BillingAddress { get;  set; }

        /// <summary>
        /// List of payment instruments selected by the buyer.
        /// </summary>
        [JsonPropertyName("paymentPreferences")]
        public List<PaymentPreferences>? PaymentPreferences { get;  set; }

        /// <summary>
        /// Merchant-provided order info.
        /// </summary>
        [JsonPropertyName("merchantMetadata")]
        public MerchantMetadata? MerchantMetadata { get;  set; }

        /// <summary>
        /// Merchant identifer of the Solution Provider (SP) - also known as ecommerce provider.
        /// </summary>
        [JsonPropertyName("platformId")]
        public string? PlatformId { get;  set; }

        /// <summary>
        /// Universal Time Coordinated (UTC) date and time when the Charge Permission was created in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("creationTimestamp")]
        public DateTime CreationTimestamp { get;  set; }

        /// <summary>
        /// UTC date and time when the Charge Permission will expire in ISO 8601 format.
        /// </summary>
        /// <remarks>The Charge Permission will expire 180 days after it's confirmed</remarks>
        [JsonPropertyName("expirationTimestamp")]
        public DateTime? ExpirationTimestamp { get;  set; }

        /// <summary>
        /// State of the Charge Permission object.
        /// </summary>
        [JsonPropertyName("statusDetails")]
        public ChargePermissionStatusDetails StatusDetails { get; set; } = null!;

        /// <summary>
        /// The currency that the buyer will be charged in ISO 4217 format.
        /// </summary>
        [JsonPropertyName("presentmentCurrency")]
        public Currency? PresentmentCurrency { get;  set; }

        /// <summary>
        /// The type of Charge Permission requested.
        /// </summary>
        [JsonPropertyName("chargePermissionType")]
        public ChargePermissionType? ChargePermissionType { get;  set; }

        /// <summary>
        /// Metadata about how the recurring Charge Permission will be used.
        /// </summary>
        [JsonPropertyName("recurringMetadata")]
        public RecurringMetadata? RecurringMetadata { get;  set; }
    }
}
