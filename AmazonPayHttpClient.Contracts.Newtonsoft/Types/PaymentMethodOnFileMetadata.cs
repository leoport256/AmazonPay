using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class PaymentMethodOnFileMetadata
{
	/// <summary>
	/// Whether to trigger only setup flow to set up payment method on file.
	/// </summary>
	[JsonProperty("setupOnly")]
	public bool SetupOnly { get; set; }
}