using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class CaptureChargeRequest
    {
        public CaptureChargeRequest(decimal amount, Currency currencyCode)
        {
            CaptureAmount = new Price(amount, currencyCode);
        }

        /// <summary>
        /// Amount to capture.
        /// </summary>
        [JsonPropertyName("captureAmount")]
        public Price CaptureAmount { get; }

        /// <summary>
        /// Description shown on the buyer's payment instrument statement..
        /// </summary>
        [JsonPropertyName("softDescriptor")]
        public string? SoftDescriptor { get; set; }
    }
}
