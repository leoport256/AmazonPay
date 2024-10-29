using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class WebCheckoutDetails
{
    /// <summary>
    /// Checkout review URL provided by the merchant. Amazon Pay will redirect to this URL after the buyer selects their preferred payment instrument and shipping address.
    /// </summary>
    [JsonPropertyName("checkoutReviewReturnUrl")]
    public string? CheckoutReviewReturnUrl { get; set; }

    /// <summary>
    /// Checkout result URL provided by the merchant. Amazon Pay will redirect to this URL after completing the transaction.
    /// </summary>
    [JsonPropertyName("checkoutResultReturnUrl")]
    public string? CheckoutResultReturnUrl { get; set; }

    /// <summary>
    /// Checkout cancel URL provided by the merchant. Amazon Pay will redirect to this URL when the checkout is cancelled on any of the Amazon Pay hosted sites.
    /// </summary>
    [JsonPropertyName("checkoutCancelUrl")]
    public string? CheckoutCancelUrl { get; set; }

    /// <summary>
    /// URL provided by Amazon Pay. Merchant will redirect to this page after setting transaction details to complete checkout.
    /// </summary>
    [JsonPropertyName("amazonPayRedirectUrl")]
    public string? AmazonPayRedirectUrl { get; set; }

    /// <summary>
    /// Specify whether the buyer will return to your website to review their order before completing checkout
    /// </summary>
    [JsonPropertyName("checkoutMode")]
    public CheckoutMode? CheckoutMode { get; set; }

}