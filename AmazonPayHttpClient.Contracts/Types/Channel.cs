namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Channel of transaction.
/// </summary>
//[JsonConverter(typeof(StringEnumConverter))]
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