using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CaptureChargeRequest
{
    public CaptureChargeRequest(decimal amount, Currency currencyCode)
    {
        CaptureAmount = new Price(amount, currencyCode);
    }

    /// <summary>
    /// Amount to capture.
    /// </summary>
    [JsonProperty("captureAmount")]
    public Price CaptureAmount { get; }

    /// <summary>
    /// Description shown on the buyer's payment instrument statement..
    /// </summary>
    [JsonProperty("softDescriptor")]
    public string? SoftDescriptor { get; set; }
}