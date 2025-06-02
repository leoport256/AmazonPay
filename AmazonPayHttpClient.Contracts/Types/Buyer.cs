using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class Buyer
{
	/// <summary>
	/// Unique Amazon Pay buyer identifier.
	/// </summary>
	[JsonPropertyName("buyerId")]
	public required string BuyerId { get; set; }

	/// <summary>
	/// Buyer name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Buyer email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Buyer Phone Number.
	/// </summary>
	[JsonPropertyName("phoneNumber")]
	public string? PhoneNumber { get; set; }

	/// <summary>
	/// Buyer PrimeMembershipTypes.
	/// </summary>
	[JsonPropertyName("primeMembershipTypes")]
	public IList<string>? PrimeMembershipTypes { get; set; }
}