using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class CloseChargePermissionRequest
{
	public CloseChargePermissionRequest(string closureReason)
	{
		ClosureReason = closureReason;
	}

	/// <summary>
	/// Merchant-provided reason for closing Charge Permission.
	/// </summary>
	[JsonPropertyName("closureReason")]
	public string ClosureReason { get; }

	/// <summary>
	/// Cancels pending charges.
	/// </summary>
	/// <remarks>
	/// Default: false.
	/// </remarks>
	[JsonPropertyName("cancelPendingCharges")]
	public bool CancelPendingCharges { get; set; }
}