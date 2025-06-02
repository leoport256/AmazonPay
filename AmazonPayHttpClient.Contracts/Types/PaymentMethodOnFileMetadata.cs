using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class PaymentMethodOnFileMetadata
{
	/// <summary>
	/// Whether to trigger only setup flow to set up payment method on file.
	/// </summary>
	[JsonPropertyName("setupOnly")]
	public bool SetupOnly { get; set; }
}