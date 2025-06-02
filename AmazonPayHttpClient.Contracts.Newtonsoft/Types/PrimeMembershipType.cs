using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Prime membership types for which the buyer is eligible.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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