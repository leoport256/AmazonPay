using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;
public sealed class RegisterAmazonPayAccountRequest
{
	/// <summary>
    /// Gets or sets the unique reference id.
    /// </summary>
    [JsonPropertyName("uniqueReferenceId")]
    public required string UniqueReferenceId { get; set; }

    /// <summary>
    /// Gets or sets the ledger currency.
    /// </summary>
    [JsonPropertyName("ledgerCurrency")]
    public required LedgerCurrency LedgerCurrency { get; set; }

    /// <summary>
    /// Gets or sets the business details.
    /// </summary>
    [JsonPropertyName("businessInfo")]
    public BusinessInfo BusinessInfo { get; } = new();

    /// <summary>
    /// Gets or sets the primary contact person.
    /// </summary>
    [JsonIgnore]
    public Person PrimaryContactPerson { get; } = new();

    [JsonPropertyName("primaryContactPerson")]
    public Person? PrimaryContactPersonRaw => PrimaryContactPerson.IsEmpty ? null : PrimaryContactPerson;

}