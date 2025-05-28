using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class DeliveryDetail
{    
	/// <summary>
	/// The shipping company code used for delivering goods to the customer.
	/// </summary>
	[JsonProperty("carrierCode")]
	public required string CarrierCode { get; set; } 

	/// <summary>
	/// The tracking number for the shipment provided by the shipping company.
	/// </summary>
	[JsonProperty("trackingNumber")]
	public required string TrackingNumber { get; set; }
}