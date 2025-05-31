using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class PaymentMethodOnFileMetadata
{
    /// <summary>
    /// Whether or not to trigger only setup flow to setup payment method on file.
    /// </summary>
    [JsonPropertyName("setupOnly")]
    public bool? SetupOnly { get; set; }
}