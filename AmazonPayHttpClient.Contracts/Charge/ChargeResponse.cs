using AmazonPayHttpClient.Contracts;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class ChargeResponse
    {
        /// <summary>
        /// Charge identifer.
        /// </summary>
        [JsonPropertyName("chargeId")]
        public string ChargeId { get; set; } = null!;

        /// <summary>
        /// Charge Permission identifer.
        /// </summary>
        [JsonPropertyName("chargePermissionId")]
        public string ChargePermissionId { get; set; } = null!;

        /// <summary>
        /// Represents the amount to be charged/authorized.
        /// </summary>
        [JsonPropertyName("chargeAmount")]
        public Price? ChargeAmount { get;  set; }

        /// <summary>
        /// The total amount that has been captured using this Charge.
        /// </summary>
        [JsonPropertyName("captureAmount")]
        public Price? CaptureAmount { get;  set; }

        /// <summary>
        /// The total amount that has been refunded using this Charge.
        /// </summary>
        [JsonPropertyName("refundedAmount")]
        public Price? RefundedAmount { get;  set; }

        /// <summary>
        /// Description shown on the buyer payment instrument statement, if CaptureNow is set to true. Do not set this value if CaptureNow is set to false.
        /// </summary>
        [JsonPropertyName("softDescriptor")]
        public string? SoftDescriptor { get;  set; }

        /// <summary>
        /// Platform ID for each Charge to be set by Solution Providers
        /// </summary>
        [JsonPropertyName("platformId")]
        public string? PlatformId { get;  set; }

        /// <summary>
        /// Boolean that indicates whether or not Charge should be captured immediately after a successful authorization.
        /// </summary>
        [JsonPropertyName("captureNow")]
        public bool? CaptureNow { get;  set; }

        /// <summary>
        /// Boolean that indicates whether merchant can handle pending response.
        /// </summary>
        [JsonPropertyName("canHandlePendingAuthorization")]
        public bool? CanHandlePendingAuthorization { get;  set; }

        /// <summary>
        /// Payment service provider (PSP)-provided order details.
        /// </summary>
        [JsonPropertyName("providerMetadata")]
        public ProviderMetadata? ProviderMetadata { get;  set; }

        /// <summary>
        /// Universal Time Coordinated (UTC) date and time when the Charge was created in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("creationTimestamp")]
        public DateTime CreationTimestamp { get;  set; }

        /// <summary>
        /// UTC date and time when the Charge will expire in ISO 8601 format.
        /// </summary>
        /// <remarks>The Charge Permission will expire 180 days after it's confirmed</remarks>
        [JsonPropertyName("expirationTimestamp")]
        public DateTime ExpirationTimestamp { get;  set; }

        /// <summary>
        /// State of the Charge object.
        /// </summary>
        [JsonPropertyName("statusDetails")]
        public StatusDetails StatusDetails { get; set; } = null!;

        /// <summary>
        /// The amount captured in disbursement currency. This is calculated using: chargeAmount/conversionRate.
        /// </summary>
        [JsonPropertyName("convertedAmount")]
        public Price? ConvertedAmount { get;  set; }

        /// <summary>
        /// The rate used to calculate convertedAmount.
        /// </summary>
        [JsonPropertyName("conversionRate")]
        public decimal? ConversionRate { get;  set; }

        /// <summary>
        /// The environment of the Amazon Pay API (live or sandbox).
        /// </summary>
        [JsonPropertyName("releaseEnvironment")]
        public string? ReleaseEnvironment { get;  set; }

        /// <summary>
        /// Merchant-provided order info.
        /// </summary>
        [JsonPropertyName("merchantMetadata")]
        public MerchantMetadata? MerchantMetadata { get;  set; }
    }
}
