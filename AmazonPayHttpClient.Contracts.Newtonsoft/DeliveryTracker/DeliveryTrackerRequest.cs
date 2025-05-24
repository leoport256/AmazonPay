using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class DeliveryTrackerRequest
{
	public DeliveryTrackerRequest()
	{
		
	}
	
	public DeliveryTrackerRequest(string objectId, bool objectIsChargePermission, string trackingNumber, string carrierCode)
	{
		if (objectIsChargePermission)
		{
			ChargePermissionId = objectId;
		}
		else
		{
			AmazonOrderReferenceId = objectId;
		}
		
		DeliveryDetails.Add(new DeliveryDetail
		{
			TrackingNumber = trackingNumber,
			CarrierCode = carrierCode
		});
	}

	
	/// <summary>
	/// The Charge Permission ID associated with the order for which the shipments need to be tracked.
	/// </summary>
	[JsonProperty("chargePermissionId")]
	public string? ChargePermissionId{ get; set; }

	
	/// <summary>
	/// The Amazon Order Reference ID associated with the order for which the shipments need to be tracked.
	/// </summary>
	[JsonProperty("amazonOrderReferenceId")]
	public string? AmazonOrderReferenceId { get; set; }


	/// <summary>
	/// Delivery details of the request.
	/// </summary>
	[JsonProperty("deliveryDetails")]
	public List<DeliveryDetail> DeliveryDetails { get; } = [];
}