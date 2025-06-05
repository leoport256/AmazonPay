using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Channel of transaction.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Channel
{
	Web,
	Phone,
	App,
	Alexa,
	PointOfSale,
	FireTv,
	Offline,
	Amazon
}