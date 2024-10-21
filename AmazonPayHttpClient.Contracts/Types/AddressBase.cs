using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public abstract class AddressBase
{
	/// <summary>
	/// Address name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The first line of the address.
	/// </summary>
	[JsonPropertyName("addressLine1")]
	public string? AddressLine1 { get; set; }

	/// <summary>
	/// The second line of the address.
	/// </summary>
	[JsonPropertyName("addressLine2")]
	public string? AddressLine2 { get; set; }

	/// <summary>
	/// The third line of the address.
	/// </summary>
	[JsonPropertyName("addressLine3")]
	public string? AddressLine3 { get; set; }

	/// <summary>
	/// City of the address.
	/// </summary>
	[JsonPropertyName("city")]
	public string? City { get; set; }

	/// <summary>
	/// The state or region.
	/// </summary>
	[JsonPropertyName("stateOrRegion")]
	public string? StateOrRegion { get; set; }

	/// <summary>
	/// Postal code of the address.
	/// </summary>
	[JsonPropertyName("postalCode")]
	public string? PostalCode { get; set; }

	/// <summary>
	/// Country code of the address in ISO 3166 format.
	/// </summary>
	[JsonPropertyName("countryCode")]
	public string? CountryCode { get; set; }

	/// <summary>
	/// Phone number.
	/// </summary>
	[JsonPropertyName("phoneNumber")]
	public string? PhoneNumber { get; set; }

	public bool IsEmpty => PhoneNumber is null && CountryCode is null && PostalCode is null &&
							StateOrRegion is null && City is null &&
							AddressLine2 is null && AddressLine3 is null && AddressLine1 is null && Name is null;

}