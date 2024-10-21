
using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class AddressDetails : AddressBase
{
    /// <summary>
    /// Distrit or County of the address.
    /// </summary>
    [JsonProperty("districtOrCounty")]
    public string? DistrictOrCounty { get; set; }
        
    [JsonIgnore]
    public new  bool IsEmpty => DistrictOrCounty is null && base.IsEmpty;

}