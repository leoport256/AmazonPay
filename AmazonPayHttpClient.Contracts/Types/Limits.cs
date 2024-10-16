using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class Limits
    {
        [JsonPropertyName("amountLimit")]
        public Price? AmountLimit { get;  set; }

        [JsonPropertyName("amountBalance")]
        public Price? AmountBalance { get;  set; }
    }
}
