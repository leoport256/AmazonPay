using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class MultiAddressesCheckoutMetadata
{
	/// <summary>
	/// Amazon Address ID from shippingAddressList in PayAndShipMultiAddress productType.
	/// </summary>
	[JsonProperty("addressId")]
	public required string AddressId { get; set; }

	/// <summary>
	/// Description of the Checkout Session constraint(s).
	/// </summary>
	[JsonProperty("price")]
	public Price? Price { get; set; }
}