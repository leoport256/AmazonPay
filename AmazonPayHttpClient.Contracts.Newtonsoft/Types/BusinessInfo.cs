using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class BusinessInfo
{
    public BusinessInfo()
    {
        BusinessAddress = new AddressInfo();
    }

    /// <summary>
    /// Gets or sets the business type.
    /// </summary>
    [JsonProperty("businessType")]
    public BusinessType? BusinessType { get; set; }

    /// <summary>
    /// Gets or sets the country of establishment.
    /// </summary>
    [JsonProperty("countryOfEstablishment")]
    public string CountryOfEstablishment { get; set; }

    /// <summary>
    /// Gets or sets the business legal name.
    /// </summary>
    [JsonProperty("businessLegalName")]
    public string BusinessLegalName { get; set; }

    /// <summary>
    /// Gets or sets the business address.
    /// </summary>
    [JsonProperty("businessAddress")]
    public AddressInfo BusinessAddress { get; set; }
}