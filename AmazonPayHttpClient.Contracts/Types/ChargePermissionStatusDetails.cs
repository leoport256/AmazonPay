using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class ChargePermissionStatusDetails
{
    /// <summary>
    /// Current object state.
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; } = null!;

    /// <summary>
    /// List of reasons for current state
    /// </summary>
    [JsonPropertyName("reasons")]
    public List<Reason>? Reasons { get;  set; }

    /// <summary>
    /// UTC date and time when the state was last updated in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("lastUpdatedTimestamp")]
    public DateTime LastUpdatedTimestamp { get;  set; }
}