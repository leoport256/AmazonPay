using Newtonsoft.Json;


namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class UpdateCheckoutSessionRequest
{
    public UpdateCheckoutSessionRequest()
    {
        WebCheckoutDetails = new WebCheckoutDetails();
        PaymentDetails = new PaymentDetails();
        MerchantMetadata = new MerchantMetadata();
        ProviderMetadata = new ProviderMetadata();
        RecurringMetadata = new RecurringMetadata();
    }

    /// <summary>
    /// URLs associated to the Checkout Session used for completing checkout
    /// </summary>
    [JsonProperty("webCheckoutDetails")]
    public WebCheckoutDetails WebCheckoutDetails { get; }

    /// <summary>
    /// Payment details specified by the merchant, such as the amount and method for charging the buyer
    /// </summary>
    [JsonProperty("paymentDetails")]
    public PaymentDetails PaymentDetails { get; }

    /// <summary>
    /// Merchant-provided order info.
    /// </summary>
    [JsonProperty("merchantMetadata")]
    public MerchantMetadata MerchantMetadata { get; }

    /// <summary>
    /// Supplementary data.
    /// </summary>
    [JsonProperty("supplementaryData")]
    public string? SupplementaryData { get; set; }

    /// <summary>
    /// Merchant identifer of the Solution Provider (SP) - also known as ecommerce provider.
    /// </summary>
    [JsonProperty("platformId")]
    public string? PlatformId { get; set; }

    /// <summary>
    /// Payment service provider (PSP)-provided order information.
    /// </summary>
    [JsonProperty("providerMetadata")]
    public ProviderMetadata ProviderMetadata { get; internal set; }

    /// <summary>
    /// Configure OneTime or Recurring payment chargePermissionType
    /// </summary>
    [JsonProperty("chargePermissionType")]
    public ChargePermissionType? ChargePermissionType { get; set; }

    /// <summary>
    /// Metadata about how the recurring Charge Permission will be used. Amazon Pay only uses this information to calculate the Charge Permission expiration date and in buyer communication,
    /// </summary>
    [JsonIgnore]
    public RecurringMetadata RecurringMetadata { get; }

    [JsonProperty("recurringMetadata")]
    public RecurringMetadata? RecurringMetadataRaw => RecurringMetadata.IsEmpty ? null : RecurringMetadata;

}