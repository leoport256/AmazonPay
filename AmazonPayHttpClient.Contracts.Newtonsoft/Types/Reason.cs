using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class Reason
{
	/// <summary>
	/// Reason code for current state.
	/// </summary>
	[JsonProperty("reasonCode")]
	public required string ReasonCode { get; set; }

	/// <summary>
	/// An optional description of the Checkout Session state.
	/// </summary>
	[JsonProperty("reasonDescription")]
	public string? ReasonDescription { get; set; }
}