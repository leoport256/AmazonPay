
using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class UpdateAmazonPayAccountRequest 
{
    /// <summary>
    /// Gets or sets the business details.
    /// </summary>
    [JsonProperty("businessInfo")]
    public BusinessInfo BusinessInfo { get; } = new();

    /// <summary>
    /// Gets or sets the primary contact person.
    /// </summary>
    [JsonIgnore]
    public Person PrimaryContactPerson { get; } = new();

    [JsonProperty("primaryContactPerson")]
    public Person? PrimaryContactPersonRaw => PrimaryContactPerson.IsEmpty ? null : PrimaryContactPerson;
}