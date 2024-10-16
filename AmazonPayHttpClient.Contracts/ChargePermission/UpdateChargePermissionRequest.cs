using System.Text.Json.Serialization;
using AmazonPayHttpClient.Contracts;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class UpdateChargePermissionRequest
    {
        public UpdateChargePermissionRequest()
        {
            MerchantMetadata = new MerchantMetadata();
            RecurringMetadata = new RecurringMetadata();
        }

        /// <summary>
        /// Merchant-provided order info.
        /// </summary>
        [JsonPropertyName("merchantMetadata")]
        public MerchantMetadata MerchantMetadata { get; }

        /// <summary>
        /// Metadata about how the recurring Charge Permission will be used.
        /// </summary>
        [JsonPropertyName("recurringMetadata")]
        public RecurringMetadata RecurringMetadata { get; }

    }
}
