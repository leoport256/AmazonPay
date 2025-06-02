using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Channel of transaction.
/// </summary>
//[JsonConverter(typeof(StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
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