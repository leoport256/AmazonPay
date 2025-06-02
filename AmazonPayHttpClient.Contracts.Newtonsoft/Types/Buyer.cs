using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class Buyer
{
	/// <summary>
	/// Unique Amazon Pay buyer identifier.
	/// </summary>
	[JsonProperty("buyerId")]
	public required string BuyerId { get; set; }

	/// <summary>
	/// Buyer name.
	/// </summary>
	[JsonProperty("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Buyer email address.
	/// </summary>
	[JsonProperty("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Buyer Phone Number.
	/// </summary>
	[JsonProperty("phoneNumber")]
	public string? PhoneNumber { get; set; }

	/// <summary>
	/// Buyer PrimeMembershipTypes.
	/// </summary>
	[JsonProperty("primeMembershipTypes")]
	public IList<string>? PrimeMembershipTypes { get; set; }
}