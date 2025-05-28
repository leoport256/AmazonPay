using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class RegisterAmazonPayAccountRequest
{
	/// <summary>
    /// Gets or sets the unique reference id.
    /// </summary>
    [JsonProperty("uniqueReferenceId")]
    public required string UniqueReferenceId { get; set; }

    /// <summary>
    /// Gets or sets the ledger currency.
    /// </summary>
    [JsonProperty("ledgerCurrency")]
    public required LedgerCurrency LedgerCurrency { get; set; }

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