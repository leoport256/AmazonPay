using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    /// <summary>
    /// Specifies whether addresses that match restrictions configuration should or should not be restricted.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RestrictionType
    {
        /// <summary>
        /// 'Allowed' - Mark addresses that don't match restrictions configuration as restricted.
        /// </summary>
        Allowed,

        /// <summary>
        /// Mark addresses that match restrictions configuration as restricted.
        /// </summary>
        NotAllowed
    }
}
