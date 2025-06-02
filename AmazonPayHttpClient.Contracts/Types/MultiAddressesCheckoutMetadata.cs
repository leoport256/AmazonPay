using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class MultiAddressesCheckoutMetadata
{
	/// <summary>
	/// Amazon Address ID from shippingAddressList in PayAndShipMultiAddress productType.
	/// </summary>
	[JsonPropertyName("addressId")]
	public required string AddressId { get; set; }

	/// <summary>
	/// Description of the Checkout Session constraint(s).
	/// </summary>
	[JsonPropertyName("price")]
	public Price? Price { get; set; }
}