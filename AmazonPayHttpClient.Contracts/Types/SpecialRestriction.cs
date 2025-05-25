using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Rule-based restrictions.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SpecialRestriction
{
    /// <summary>
    /// Marks PO box addresses in US, CA, GB, FR, DE, ES, PT, IT, AU as restricted
    /// </summary>
    RestrictPOBoxes,

    /// <summary>
    /// Marks packstation addresses in DE as restricted
    /// </summary>
    RestrictPackstations
}