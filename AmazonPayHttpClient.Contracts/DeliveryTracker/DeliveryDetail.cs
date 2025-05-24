using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class DeliveryDetail
{    
	/// <summary>
	/// The shipping company code used for delivering goods to the customer.
	/// </summary>
	[JsonPropertyName("carrierCode")]
	public required string CarrierCode { get; set; } 

	/// <summary>
	/// The tracking number for the shipment provided by the shipping company.
	/// </summary>
	[JsonPropertyName("trackingNumber")]
	public required string TrackingNumber { get; set; }
}