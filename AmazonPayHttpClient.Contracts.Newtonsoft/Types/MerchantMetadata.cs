using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class MerchantMetadata
{
	/// <summary>
	/// External merchant order identifer.
	/// </summary>
	[JsonProperty("merchantReferenceId")]
	public string? MerchantReferenceId { get; set; }

	/// <summary>
	/// Merchant store name.
	/// </summary>
	[JsonProperty("merchantStoreName")]
	public string? MerchantStoreName { get; set; }

	/// <summary>
	/// Description of the order that is shared in buyer communication.
	/// </summary>
	[JsonProperty("noteToBuyer")]
	public string? NoteToBuyer { get; set; }

	/// <summary>
	/// Custom info for the order. This data is not shared in any buyer communication.
	/// </summary>
	[JsonProperty("customInformation")]
	public string? CustomInformation { get; set; }
}