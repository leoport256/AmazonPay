using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    /// <summary>
    /// Rule-based restrictions.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpecialRestriction
    {
        /// <summary>
        /// Marks PO box addresses in US, CA, GB, FR, DE, ES, PT, IT, AU as restricted
        /// </summary>
        [EnumMember(Value = "restrictPOBoxes")]
        RestrictPOBoxes,

        /// <summary>
        /// Marks packstation addresses in DE as restricted
        /// </summary>
        [EnumMember(Value = "restrictPackstations")]
        RestrictPackstations
    }
}
