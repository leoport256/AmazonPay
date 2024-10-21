using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CancelChargeRequest
{
    public CancelChargeRequest(string cancellationReason)
    {
        CancellationReason = cancellationReason;
    }

    /// <summary>
    /// Merchant-provided reason for canceling Charge.
    /// </summary>
    [JsonProperty("cancellationReason")]
    public string CancellationReason { get; }
}