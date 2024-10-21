using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// The type of Charge Permission requested.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChargePermissionType
{

    OneTime,
    Recurring
}