using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class DeliveryTrackerResponse
{
	/// <summary>
	/// The Amazon Order Reference ID associated with the order for which the shipments need to be tracked.
	/// </summary>
	[JsonProperty("amazonOrderReferenceId")]
	public string? AmazonOrderReferenceId { get; set; }

	/// <summary>
	/// The Charge Permission ID associated with the order for which the shipments need to be tracked.
	/// </summary>
	[JsonProperty("chargePermissionId")]
	public string? ChargePermissionId { get; set; }
	
	/// <summary>
	/// Delivery details of the request.
	/// </summary>
	[JsonProperty("deliveryDetails")]
	public List<DeliveryDetail>? DeliveryDetails { get; set; }
}