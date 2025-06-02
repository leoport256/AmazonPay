using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class BuyerResponse
{
    /// <summary>
    /// Unique Amazon Pay buyer identifier.
    /// </summary>
    [JsonProperty("buyerId")]
    public string? BuyerId { get;  set; }

    /// <summary>
    /// Buyer default shipping address country.
    /// </summary>
    [JsonProperty("countryCode")]
    public string? CountryCode { get;  set; }

    /// <summary>
    /// Buyer name.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get;  set; }

    /// <summary>
    /// Buyer email address.
    /// </summary>
    [JsonProperty("email")]
    public string? Email { get;  set; }

    /// <summary>
    /// Buyer default shipping address postal code.
    /// </summary>
    [JsonProperty("postalCode")]
    public string? PostalCode { get;  set; }

    /// <summary>
    /// Shipping address selected by the buyer.
    /// </summary>
    [JsonProperty("shippingAddress")]
    public Address? ShippingAddress { get;  set; }

    /// <summary>
    ///  Billing address for buyer-selected payment instrument.
    /// </summary>
    [JsonProperty("billingAddress")]
    public Address? BillingAddress { get;  set; }

    /// <summary>
    ///  PrimeMembershipTypes of the buyer, available by allow list only.  If merchant account is not part of allow list, the value will be null.  Empty list is returned if buyer is not eligible for any of the benefits.
    /// </summary>
    [JsonProperty("primeMembershipTypes")]
    public List<string> PrimeMembershipTypes { get; set; } = [];
}