using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// The buyer details that you're requesting access for.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignInScope
{
    /// <summary>
    /// Request access to buyer name.
    /// </summary>
    Name,

    /// <summary>
    /// Request access to buyer email address.
    /// </summary>
    Email,

    /// <summary>
    /// Request access to buyer default shipping address postal code and country code.
    /// </summary>
    PostalCode,

    /// <summary>
    /// Request access to buyer default full shipping address (including postal code and country code).
    /// </summary>
    ShippingAddress,

    /// <summary>
    /// Request access to buyer default phone number.
    /// </summary>
    PhoneNumber,

    /// <summary>
    /// Request access to buyer prime membership status.
    /// </summary>
    PrimeStatus,

    /// <summary>
    /// Request access to buyer default full billing address (including postal code and country code).
    /// </summary>
    BillingAddress
}