using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    public sealed class ProviderMetadata
    {
        /// <summary>
        /// Payment service provider (PSP)-provided order identifier.
        /// </summary>
        [JsonProperty("providerReferenceId")]
        public string? ProviderReferenceId { get; set; }

        [JsonIgnore]
        public bool IsEmpty => string.IsNullOrEmpty(ProviderReferenceId);
    }
}
