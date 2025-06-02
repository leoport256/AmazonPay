using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class RegisterAmazonPayAccountResponse
{
	/// <summary>
	/// Gets or sets the unique reference id.
	/// </summary>
	[JsonPropertyName("uniqueReferenceId")]
	public required string UniqueReferenceId { get; set; }

	/// <summary>
	/// Gets or sets the merchant account id.
	/// </summary>
	[JsonPropertyName("merchantAccountId")]
	public required string MerchantAccountId { get; set; }
}