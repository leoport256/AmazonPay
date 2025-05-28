using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class PaymentMethodOnFileMetadata
{
    /// <summary>
    /// Whether or not to trigger only setup flow to setup payment method on file.
    /// </summary>
    [JsonProperty("setupOnly")]
    public bool? SetupOnly { get; set; }
}