using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public abstract class AddressInfoBase
{
    /// <summary>
    /// Gets or sets address line 1.
    /// </summary>
    [JsonProperty("addressLine1")]
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// Gets or sets address line 2.
    /// </summary>
    [JsonProperty("addressLine2")]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Gets or sets the City.
    /// </summary>
    [JsonProperty("city")]
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets state or region.
    /// </summary>
    [JsonProperty("stateOrRegion")]
    public string? StateOrRegion { get; set; }

    /// <summary>
    /// Gets or sets postal code.
    /// </summary>
    [JsonProperty("postalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Gets or sets postal code.
    /// </summary>
    [JsonProperty("countryCode")]
    public string? CountryCode { get; set; }


    public bool IsEmpty => CountryCode is null && PostalCode is null && StateOrRegion is null && City is null &&
                           AddressLine2 is null && AddressLine1 is null;
}