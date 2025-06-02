using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class ChargePermissionStatusDetails
{
	/// <summary>
	/// Current object state.
	/// </summary>
	[JsonProperty("state")]
	public string State { get; set; } = null!;

	/// <summary>
	/// List of reasons for current state
	/// </summary>
	[JsonProperty("reasons")]
	public List<Reason>? Reasons { get; set; }

	/// <summary>
	/// UTC date and time when the state was last updated in ISO 8601 format.
	/// </summary>
	[JsonProperty("lastUpdatedTimestamp")]
	public DateTime LastUpdatedTimestamp { get; set; }
}