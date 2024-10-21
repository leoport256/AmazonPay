using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class ChargeResponse
{
    /// <summary>
    /// Charge identifer.
    /// </summary>
    [JsonProperty("chargeId")]
    public string ChargeId { get; set; } = null!;

    /// <summary>
    /// Charge Permission identifer.
    /// </summary>
    [JsonProperty("chargePermissionId")]
    public string ChargePermissionId { get; set; } = null!;

    /// <summary>
    /// Represents the amount to be charged/authorized.
    /// </summary>
    [JsonProperty("chargeAmount")]
    public Price? ChargeAmount { get;  set; }

    /// <summary>
    /// The total amount that has been captured using this Charge.
    /// </summary>
    [JsonProperty("captureAmount")]
    public Price? CaptureAmount { get;  set; }

    /// <summary>
    /// The total amount that has been refunded using this Charge.
    /// </summary>
    [JsonProperty("refundedAmount")]
    public Price? RefundedAmount { get;  set; }

    /// <summary>
    /// Description shown on the buyer payment instrument statement, if CaptureNow is set to true. Do not set this value if CaptureNow is set to false.
    /// </summary>
    [JsonProperty("softDescriptor")]
    public string? SoftDescriptor { get;  set; }

    /// <summary>
    /// Platform ID for each Charge to be set by Solution Providers
    /// </summary>
    [JsonProperty("platformId")]
    public string? PlatformId { get;  set; }

    /// <summary>
    /// Boolean that indicates whether or not Charge should be captured immediately after a successful authorization.
    /// </summary>
    [JsonProperty("captureNow")]
    public bool? CaptureNow { get;  set; }

    /// <summary>
    /// Boolean that indicates whether merchant can handle pending response.
    /// </summary>
    [JsonProperty("canHandlePendingAuthorization")]
    public bool? CanHandlePendingAuthorization { get;  set; }

    /// <summary>
    /// Payment service provider (PSP)-provided order details.
    /// </summary>
    [JsonProperty("providerMetadata")]
    public ProviderMetadata? ProviderMetadata { get;  set; }

    /// <summary>
    /// Universal Time Coordinated (UTC) date and time when the Charge was created in ISO 8601 format.
    /// </summary>
    [JsonProperty("creationTimestamp")]
    public DateTime CreationTimestamp { get;  set; }

    /// <summary>
    /// UTC date and time when the Charge will expire in ISO 8601 format.
    /// </summary>
    /// <remarks>The Charge Permission will expire 180 days after it's confirmed</remarks>
    [JsonProperty("expirationTimestamp")]
    public DateTime ExpirationTimestamp { get;  set; }

    /// <summary>
    /// State of the Charge object.
    /// </summary>
    [JsonProperty("statusDetails")]
    public StatusDetails StatusDetails { get; set; } = null!;

    /// <summary>
    /// The amount captured in disbursement currency. This is calculated using: chargeAmount/conversionRate.
    /// </summary>
    [JsonProperty("convertedAmount")]
    public Price? ConvertedAmount { get;  set; }

    /// <summary>
    /// The rate used to calculate convertedAmount.
    /// </summary>
    [JsonProperty("conversionRate")]
    public decimal? ConversionRate { get;  set; }

    /// <summary>
    /// The environment of the Amazon Pay API (live or sandbox).
    /// </summary>
    [JsonProperty("releaseEnvironment")]
    public string? ReleaseEnvironment { get;  set; }

    /// <summary>
    /// Merchant-provided order info.
    /// </summary>
    [JsonProperty("merchantMetadata")]
    public MerchantMetadata? MerchantMetadata { get;  set; }
}