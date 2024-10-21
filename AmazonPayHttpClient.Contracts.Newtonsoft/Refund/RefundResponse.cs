using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class RefundResponse
{
    /// <summary>
    /// Refund identifier.
    /// </summary>
    [JsonProperty("refundId")]
    public string RefundId { get;  set; } = null!;

    /// <summary>
    /// Charge identifer.
    /// </summary>
    [JsonProperty("chargeId")]
    public string ChargeId { get; set; } = null!;

    /// <summary>
    /// Amount to be refunded. Refund amount can be either 15% or 75 USD/GBP/EUR (whichever is less) above the captured amount.
    /// </summary>
    [JsonProperty("refundAmount")]
    public Price? RefundAmount { get;  set; }

    /// <summary>
    /// Description shown on the buyer payment instrument statement.
    /// </summary>
    [JsonProperty("softDescriptor")]
    public string? SoftDescriptor { get;  set; }

    /// <summary>
    /// UTC date and time when the refund was created in ISO 8601 format.
    /// </summary>
    [JsonProperty("creationTimestamp")]
    public DateTime CreationTimestamp { get;  set; }

    /// <summary>
    /// State of the refund object.
    /// </summary>
    [JsonProperty("statusDetails")]
    public StatusDetails StatusDetails { get; set; } = null!;

    /// <summary>
    /// The environment of the Amazon Pay API (live or sandbox).
    /// </summary>
    [JsonProperty("releaseEnvironment")]
    public string? ReleaseEnvironment { get;  set; }
}