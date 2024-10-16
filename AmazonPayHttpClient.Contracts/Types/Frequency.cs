using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{

    /// <summary>
    /// Frequency at which the buyer will be charged using a recurring Charge Permission.
    /// </summary>
    public sealed class Frequency
    {
        /// <summary>
        /// Frequency unit for each billing cycle. Supported values: 'Year', 'Month', 'Week', 'Day'.
        /// </summary>
        [JsonPropertyName("unit")]
        public FrequencyUnit? Unit { get; set; }

        /// <summary>
        /// Number of frequency units per billing cycle. For example, to specify a weekly cycle set unit to Week and value to 1.
        /// </summary>
        [JsonPropertyName("value")]
        public int? Value { get; set; }

        [JsonIgnore]
        public bool IsEmpty => Unit is null && Value is null;
    }
}
