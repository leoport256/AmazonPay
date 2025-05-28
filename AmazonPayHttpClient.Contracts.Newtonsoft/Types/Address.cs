
using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class Address : AddressBase
{
    /// <summary>
    /// County of the address.
    /// </summary>
    [JsonProperty("county")]
    public string? County { get;  set; }

    /// <summary>
    /// District of the address.
    /// </summary>
    [JsonProperty("district")]
    public string? District { get;  set; }
}