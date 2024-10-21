using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class ProviderMetadata
{
    /// <summary>
    /// Payment service provider (PSP)-provided order identifier.
    /// </summary>
    [JsonPropertyName("providerReferenceId")]
    public string? ProviderReferenceId { get; set; }

    [JsonIgnore]
    public bool IsEmpty => string.IsNullOrEmpty(ProviderReferenceId);
}