using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class Person
{
	/// <summary>
	/// Gets or sets the person full name.
	/// </summary>
	[JsonProperty("personFullName")]
	public string? PersonFullName { get; set; }

	public bool IsEmpty => PersonFullName is null;

	/// <summary>
	/// Gets or sets the residential address.
	/// </summary>
	[System.Text.Json.Serialization.JsonIgnore]
	public AddressInfo ResidentialAddress { get; set; } = new();


	[JsonProperty("residentialAddress")]
	public AddressInfo? ResidentialAddressRaw => ResidentialAddress.IsEmpty ? null : ResidentialAddress;

	/// <summary>
	/// Gets or sets the date of birth.
	/// </summary>
	[JsonProperty("dateOfBirth")]
	public string? DateOfBirth { get; set; }
}