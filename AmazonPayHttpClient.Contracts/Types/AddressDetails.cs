
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class AddressDetails : AddressBase
    {
        /// <summary>
        /// Distrit or County of the address.
        /// </summary>
        [JsonPropertyName("districtOrCounty")]
        public string? DistrictOrCounty { get; set; }
        
        [JsonIgnore]
        public new  bool IsEmpty => DistrictOrCounty is null && base.IsEmpty;

    }
}
