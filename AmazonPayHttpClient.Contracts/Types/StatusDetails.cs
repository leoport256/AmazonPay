using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class StatusDetails
{
    /// <summary>
    /// Current object state.
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; } = null!;

    /// <summary>
    /// Reason code for current state.
    /// </summary>
    [JsonPropertyName("reasonCode")]
    public string? ReasonCode { get;  set; }

    /// <summary>
    /// An optional description of the Checkout Session state.
    /// </summary>
    [JsonPropertyName("reasonDescription")]
    public string? ReasonDescription { get;  set; }

    /// <summary>
    /// UTC date and time when the state was last updated in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("lastUpdatedTimestamp")]
    public DateTime LastUpdatedTimestamp { get;  set; }
}