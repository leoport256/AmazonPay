using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class Reason
    {
        /// <summary>
        /// Reason code for current state.
        /// </summary>
        [JsonPropertyName("reasonCode")]
        public string ReasonCode { get; set; } = null!;

        /// <summary>
        /// An optional description of the Checkout Session state.
        /// </summary>
        [JsonPropertyName("reasonDescription")]
        public string? ReasonDescription { get; set; }
    }
}
