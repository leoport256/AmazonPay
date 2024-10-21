using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

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
    [JsonProperty("merchantMetadata")]
    public MerchantMetadata MerchantMetadata { get; }

    /// <summary>
    /// Metadata about how the recurring Charge Permission will be used.
    /// </summary>
    [JsonProperty("recurringMetadata")]
    public RecurringMetadata RecurringMetadata { get; }

}