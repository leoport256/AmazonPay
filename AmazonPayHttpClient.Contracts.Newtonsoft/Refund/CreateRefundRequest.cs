using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CreateRefundRequest
{
    public CreateRefundRequest(string chargeId, decimal refundAmount, Currency currencyCode)
    {
        ChargeId = chargeId;
        RefundAmount = new Price(refundAmount, currencyCode);
    }

    /// <summary>
    /// Charge identifer.
    /// </summary>
    [JsonProperty("chargeId")]
    public string ChargeId { get; }

    /// <summary>
    /// Amount to be refunded. Refund amount can be either 15% or 75 USD/GBP/EUR (whichever is less) above the captured amount.
    /// </summary>
    [JsonProperty("refundAmount")]
    public Price RefundAmount { get; }

    /// <summary>
    /// Description shown on the buyer payment instrument statement.
    /// </summary>
    [JsonProperty("softDescriptor")]
    public string? SoftDescriptor { get; set; }
}