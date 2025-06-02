using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Payment flow for charging the buyer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PaymentIntent
{
	Confirm,
	Authorize,
	AuthorizeWithCapture
}