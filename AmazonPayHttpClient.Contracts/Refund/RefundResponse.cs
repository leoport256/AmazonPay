using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class RefundResponse
{
	/// <summary>
	/// Refund identifier.
	/// </summary>
	[JsonPropertyName("refundId")]
	public required string RefundId { get; set; }

	/// <summary>
	/// Charge identifer.
	/// </summary>
	[JsonPropertyName("chargeId")]
	public required string ChargeId { get; set; }

	/// <summary>
	/// Amount to be refunded. Refund amount can be either 15% or 75 USD/GBP/EUR (whichever is less) above the captured amount.
	/// </summary>
	[JsonPropertyName("refundAmount")]
	public Price? RefundAmount { get; set; }

	/// <summary>
	/// Description shown on the buyer payment instrument statement.
	/// </summary>
	[JsonPropertyName("softDescriptor")]
	public string? SoftDescriptor { get; set; }

	/// <summary>
	/// UTC date and time when the refund was created in ISO 8601 format.
	/// </summary>
	[JsonPropertyName("creationTimestamp")]
	public DateTime CreationTimestamp { get; set; }

	/// <summary>
	/// State of the refund object.
	/// </summary>
	[JsonPropertyName("statusDetails")]
	public StatusDetails? StatusDetails { get; set; }

	/// <summary>
	/// The environment of the Amazon Pay API (live or sandbox).
	/// </summary>
	[JsonPropertyName("releaseEnvironment")]
	public string ReleaseEnvironment { get; set; } = "sandbox";
}