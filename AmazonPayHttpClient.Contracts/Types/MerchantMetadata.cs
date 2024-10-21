using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class MerchantMetadata
{
    /// <summary>
    /// External merchant order identifer.
    /// </summary>
    [JsonPropertyName("merchantReferenceId")]
    public string? MerchantReferenceId { get; set; }

    /// <summary>
    /// Merchant store name.
    /// </summary>
    [JsonPropertyName("merchantStoreName")]
    public string? MerchantStoreName { get; set; }

    /// <summary>
    /// Description of the order that is shared in buyer communication.
    /// </summary>
    [JsonPropertyName("noteToBuyer")]
    public string? NoteToBuyer { get; set; }

    /// <summary>
    /// Custom info for the order. This data is not shared in any buyer communication.
    /// </summary>
    [JsonPropertyName("customInformation")]
    public string? CustomInformation { get; set; }
}