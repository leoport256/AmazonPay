using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class AddressWithId : Address
{
	/// <summary>
	/// Amazon Address ID from shippingAddressList in PayAndShipMultiAddress productType.
	/// </summary>
	[JsonPropertyName("addressId")]
	public required string AddressId { get; set; }
}