using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class StatusDetails
{
    /// <summary>
    /// Current object state.
    /// </summary>
    [JsonProperty("state")]
    public string State { get; set; } = null!;

    /// <summary>
    /// Reason code for current state.
    /// </summary>
    [JsonProperty("reasonCode")]
    public string? ReasonCode { get;  set; }

    /// <summary>
    /// An optional description of the Checkout Session state.
    /// </summary>
    [JsonProperty("reasonDescription")]
    public string? ReasonDescription { get;  set; }

    /// <summary>
    /// UTC date and time when the state was last updated in ISO 8601 format.
    /// </summary>
    [JsonProperty("lastUpdatedTimestamp")]
    public DateTime LastUpdatedTimestamp { get;  set; }
}