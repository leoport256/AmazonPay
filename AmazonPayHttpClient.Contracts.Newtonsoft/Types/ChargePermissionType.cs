using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// The type of Charge Permission requested.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChargePermissionType
{

    OneTime,
    Recurring
}