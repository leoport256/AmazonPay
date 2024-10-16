using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class CancelChargeRequest
    {
        public CancelChargeRequest(string cancellationReason)
        {
            CancellationReason = cancellationReason;
        }

        /// <summary>
        /// Merchant-provided reason for canceling Charge.
        /// </summary>
        [JsonPropertyName("cancellationReason")]
        public string CancellationReason { get; }
    }
}
