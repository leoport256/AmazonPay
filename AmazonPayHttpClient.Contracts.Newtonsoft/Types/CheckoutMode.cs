using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    /// <summary>
    /// Specify whether the buyer will return to your website to review their order before completing checkout.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum CheckoutMode
    {
        ProcessOrder
    }
}
