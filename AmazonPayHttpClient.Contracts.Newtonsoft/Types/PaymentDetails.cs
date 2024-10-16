using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    public sealed class PaymentDetails
    {
        public PaymentDetails()
        {
            ChargeAmount = new Price();
            TotalOrderAmount = new Price();
        }

        /// <summary>
        /// Payment flow for charging the buyer.
        /// </summary>
        [JsonProperty("paymentIntent")]
        public PaymentIntent? PaymentIntent { get; set; }

        /// <summary>
        /// Boolean that indicates whether merchant can handle pending response.
        /// </summary>
        [JsonProperty("canHandlePendingAuthorization")]
        public bool CanHandlePendingAuthorization { get; set; }

        /// <summary>
        /// Amount to be processed using paymentIntent during checkout.
        /// </summary>
        [JsonIgnore]
        public Price ChargeAmount { get; private set; }

        [JsonProperty("chargeAmount")]
        public Price? ChargeAmountRaw
        {
            get => ChargeAmount.IsEmpty ? null : ChargeAmount;
            set => ChargeAmount = value is null || value.IsEmpty ? new Price() : value;
        }

        /// <summary>
        /// Total order amount, only use this parameter if you need to process additional payments after checkout.
        /// </summary>
        [JsonIgnore]
        public Price TotalOrderAmount { get; private set; }
        
        [JsonProperty("totalOrderAmount")]
        public Price? TotalOrderAmountRaw
        {
            get => TotalOrderAmount.IsEmpty ? null : TotalOrderAmount;
            set => TotalOrderAmount = value is null || value.IsEmpty ? new Price() : value;
        }

        /// <summary>
        /// The currency that the buyer will be charged in ISO 4217 format. Example: USD.
        /// </summary>
        [JsonProperty("presentmentCurrency")]
        public Currency? PresentmentCurrency { get; set; }

        /// <summary>
        /// Boolean that indicates whether merchant can charge the buyer beyond the specified order amount.
        /// </summary>
        [JsonProperty("allowOvercharge")]
        public bool? AllowOvercharge { get; set; }

        /// <summary>
        /// Boolean that indicates whether to create a ChargePermission with an extended expiration
        /// period of 13 months as compared to the default expiration period of 180 days(6 months).
        /// </summary>
        [JsonProperty("extendExpiration")]
        public bool? ExtendExpiration { get; set; }

        /// <summary>
        /// Description shown on the buyer payment instrument statement, if PaymentIntent is set to AuthorizeWithCapture.
        /// Do not use if PaymentIntent is set to Confirm or Authorize.
        /// </summary>
        [JsonProperty("softDescriptor")]
        public string? SoftDescriptor { get; set; }

        /// <summary>
        /// Estimate Order Total. TODO : Replace this with the version from the guide, once available
        /// </summary>
        [JsonProperty("estimateOrderTotal")]
        public Price? EstimateOrderTotal { get; set; }
    }
}
