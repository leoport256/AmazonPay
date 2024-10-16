using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    public class PaymentPreferences
    {
        /// <summary>
        /// Amazon Pay-provided description for buyer-selected payment instrument.
        /// </summary>
        [JsonProperty("paymentDescriptor")]
        public string? PaymentDescriptor { get; set; }
    }
}
