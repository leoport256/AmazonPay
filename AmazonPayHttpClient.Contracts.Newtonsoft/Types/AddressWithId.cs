using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class AddressWithId : Address
{
	/// <summary>
	/// Amazon Address ID from shippingAddressList in PayAndShipMultiAddress productType.
	/// </summary>
	[JsonProperty("addressId")]
	public required string AddressId { get; set; }
}