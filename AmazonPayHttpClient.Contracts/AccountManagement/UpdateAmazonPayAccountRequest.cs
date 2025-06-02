using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class UpdateAmazonPayAccountRequest
{
	/// <summary>
	/// Gets or sets the business details.
	/// </summary>
	[JsonPropertyName("businessInfo")]
	public BusinessInfo BusinessInfo { get; } = new();

	/// <summary>
	/// Gets or sets the primary contact person.
	/// </summary>
	[JsonIgnore]
	public Person PrimaryContactPerson { get; } = new();

	[JsonPropertyName("primaryContactPerson")]
	public Person? PrimaryContactPersonRaw => PrimaryContactPerson.IsEmpty ? null : PrimaryContactPerson;
}