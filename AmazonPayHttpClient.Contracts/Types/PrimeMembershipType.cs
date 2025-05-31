using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Prime membership types for which the buyer is eligible.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PrimeMembershipType
{
    // ReSharper disable once InconsistentNaming
    NONE = 0,
    // ReSharper disable once InconsistentNaming
    PRIME_GENERAL = 1,
    // ReSharper disable once InconsistentNaming
    PRIME_STUDENT = 2,
    // ReSharper disable once InconsistentNaming
    PRIME_GENERAL_US = 3
}