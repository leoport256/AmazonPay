using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    public sealed class Limits
    {
        [JsonProperty("amountLimit")]
        public Price? AmountLimit { get;  set; }

        [JsonProperty("amountBalance")]
        public Price? AmountBalance { get;  set; }
    }
}
