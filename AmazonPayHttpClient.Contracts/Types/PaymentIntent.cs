using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    /// <summary>
    /// Payment flow for charging the buyer.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentIntent
    {
        Confirm,
        Authorize,
        AuthorizeWithCapture
    }
}
