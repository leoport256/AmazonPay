using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class BusinessInfo
{
	/// <summary>
	/// Gets or sets the business type.
	/// </summary>
	[JsonPropertyName("businessType")]
	public BusinessType? BusinessType { get; set; }

	/// <summary>
	/// Gets or sets the country of establishment.
	/// </summary>
	[JsonPropertyName("countryOfEstablishment")]
	public string? CountryOfEstablishment { get; set; }

	/// <summary>
	/// Gets or sets the business legal name.
	/// </summary>
	[JsonPropertyName("businessLegalName")]
	public string? BusinessLegalName { get; set; }

	/// <summary>
	/// Gets or sets the business address.
	/// </summary>
	[JsonPropertyName("businessAddress")]
	public AddressInfo BusinessAddress { get; set; } = new();
}