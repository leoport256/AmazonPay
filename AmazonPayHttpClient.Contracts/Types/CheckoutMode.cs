using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Specify whether the buyer will return to your website to review their order before completing checkout.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CheckoutMode
{
    ProcessOrder
}