using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    public sealed class CloseChargePermissionRequest
    {
        public CloseChargePermissionRequest(string closureReason)
        {
            ClosureReason = closureReason;
        }

        /// <summary>
        /// Merchant-provided reason for closing Charge Permission.
        /// </summary>
        [JsonProperty("closureReason")]
        public string ClosureReason { get; }

        /// <summary>
        /// Cancels pending charges.
        /// </summary>
        /// <remarks>
        /// Default: false.
        /// </remarks>
        [JsonProperty("cancelPendingCharges")]
        public bool? CancelPendingCharges { get; set; }
    }
}
