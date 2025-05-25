
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class Address : AddressBase
{
    /// <summary>
    /// County of the address.
    /// </summary>
    [JsonPropertyName("county")]
    public string? County { get;  set; }

    /// <summary>
    /// District of the address.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get;  set; }
}