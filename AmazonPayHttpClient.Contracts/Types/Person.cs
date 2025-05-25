using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class Person
{
    public Person()
    {
        ResidentialAddress = new AddressInfo();
    }

    /// <summary>
    /// Gets or sets the person full name.
    /// </summary>
    [JsonPropertyName("personFullName")]
    public string? PersonFullName { get; set; }

    public bool IsEmpty => PersonFullName is null;
    
    /// <summary>
    /// Gets or sets the residential address.
    /// </summary>
    [JsonIgnore]
    public AddressInfo ResidentialAddress { get; set; }


    [JsonPropertyName("residentialAddress")]
    public AddressInfo? ResidentialAddressRaw => ResidentialAddress.IsEmpty ? null : ResidentialAddress;
        
    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public string DateOfBirth { get; set; }
}