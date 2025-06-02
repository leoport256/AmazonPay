using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class RegisterAmazonPayAccountResponse
{
    /// <summary>
    /// Gets or sets the unique reference id.
    /// </summary>
    [JsonProperty("uniqueReferenceId")]
    public required string UniqueReferenceId { get; set; }

    /// <summary>
    /// Gets or sets the merchant account id.
    /// </summary>
    [JsonProperty("merchantAccountId")]
    public required string MerchantAccountId { get; set; }
}