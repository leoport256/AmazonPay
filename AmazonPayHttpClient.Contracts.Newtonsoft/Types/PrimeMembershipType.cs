using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Prime membership types for which the buyer is eligible.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PrimeMembershipType
{
    NONE = 0,
    PRIME_GENERAL = 1,
    PRIME_STUDENT = 2,
    PRIME_GENERAL_US = 3
}