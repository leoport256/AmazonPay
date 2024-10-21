using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class PaymentDetails
{
    public PaymentDetails()
    {
        ChargeAmount = new Price();
        TotalOrderAmount = new Price();
    }

    /// <summary>
    /// Payment flow for charging the buyer.
    /// </summary>
    [JsonPropertyName("paymentIntent")]
    public PaymentIntent? PaymentIntent { get; set; }

    /// <summary>
    /// Boolean that indicates whether merchant can handle pending response.
    /// </summary>
    [JsonPropertyName("canHandlePendingAuthorization")]
    public bool CanHandlePendingAuthorization { get; set; }

    /// <summary>
    /// Amount to be processed using paymentIntent during checkout.
    /// </summary>
    [JsonIgnore]
    public Price ChargeAmount { get; private set; }

    [JsonPropertyName("chargeAmount")]
    public Price? ChargeAmountRaw
    {
        get => ChargeAmount.IsEmpty ? null : ChargeAmount;
        set => ChargeAmount = value is null || value.IsEmpty ? new Price() : value;
    }

    /// <summary>
    /// Total order amount, only use this parameter if you need to process additional payments after checkout.
    /// </summary>
    [JsonIgnore]
    public Price TotalOrderAmount { get; private set; }
        
    [JsonPropertyName("totalOrderAmount")]
    public Price? TotalOrderAmountRaw
    {
        get => TotalOrderAmount.IsEmpty ? null : TotalOrderAmount;
        set => TotalOrderAmount = value is null || value.IsEmpty ? new Price() : value;
    }

    /// <summary>
    /// The currency that the buyer will be charged in ISO 4217 format. Example: USD.
    /// </summary>
    [JsonPropertyName("presentmentCurrency")]
    public Currency? PresentmentCurrency { get; set; }

    /// <summary>
    /// Boolean that indicates whether merchant can charge the buyer beyond the specified order amount.
    /// </summary>
    [JsonPropertyName("allowOvercharge")]
    public bool? AllowOvercharge { get; set; }

    /// <summary>
    /// Boolean that indicates whether to create a ChargePermission with an extended expiration
    /// period of 13 months as compared to the default expiration period of 180 days(6 months).
    /// </summary>
    [JsonPropertyName("extendExpiration")]
    public bool? ExtendExpiration { get; set; }

    /// <summary>
    /// Description shown on the buyer payment instrument statement, if PaymentIntent is set to AuthorizeWithCapture.
    /// Do not use if PaymentIntent is set to Confirm or Authorize.
    /// </summary>
    [JsonPropertyName("softDescriptor")]
    public string? SoftDescriptor { get; set; }

    /// <summary>
    /// Estimate Order Total. TODO : Replace this with the version from the guide, once available
    /// </summary>
    [JsonPropertyName("estimateOrderTotal")]
    public Price? EstimateOrderTotal { get; set; }
}