using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class DeliveryTrackerResponse
{
	/// <summary>
	/// The Amazon Order Reference ID associated with the order for which the shipments need to be tracked.
	/// </summary>
	[JsonPropertyName("amazonOrderReferenceId")]
	public string? AmazonOrderReferenceId { get; set; }

	/// <summary>
	/// The Charge Permission ID associated with the order for which the shipments need to be tracked.
	/// </summary>
	[JsonPropertyName("chargePermissionId")]
	public string? ChargePermissionId { get; set; }
	
	/// <summary>
	/// Delivery details of the request.
	/// </summary>
	[JsonPropertyName("deliveryDetails")]
	public List<DeliveryDetail>? DeliveryDetails { get; set; }
}