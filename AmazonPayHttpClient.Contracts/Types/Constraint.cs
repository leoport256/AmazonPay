using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class Constraint
    {
        /// <summary>
        /// Code for any Checkout Session constraint(s).
        /// </summary>
        [JsonPropertyName("constraintId")]
        public string ConstraintId { get; set; } = null!;

        /// <summary>
        /// Description of the Checkout Session constraint(s).
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get;  set; }
    }
}
