using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class FinalizeCheckoutSessionRequest
{
	       /// <summary>
        /// Initializes a new instance of the FinalizeCheckoutSessionRequest class with specified amount and currency.
        /// </summary>
        public FinalizeCheckoutSessionRequest(decimal amount, Currency currency, PaymentIntent paymentIntent)
        {
            ChargeAmount = new Price(amount, currency);
            PaymentIntent = paymentIntent;
        }
        
        /// <summary>
        /// Initializes a new instance of the FinalizeCheckoutSessionRequest class.
        /// </summary>
        public FinalizeCheckoutSessionRequest(PaymentIntent paymentIntent)
        {
            ChargeAmount = new Price();
            PaymentIntent = paymentIntent;
        }
    

        /// <summary>
        /// Gets or sets the payment intent.
        /// </summary>
        [JsonPropertyName("paymentIntent")]
        public PaymentIntent PaymentIntent { get;}
        
        /// <summary>
        /// Gets or sets can handle pending authorization.
        /// </summary>
        [JsonPropertyName("canHandlePendingAuthorization")]
        public bool? CanHandlePendingAuthorization { get; set; }
        
        /// <summary>
        /// Gets or sets supplementary data.
        /// </summary>
        [JsonPropertyName("supplementaryData")]
        public string? SupplementaryData { get; set; }
        
        /// <summary>
        /// Gets or sets shipping address.
        /// </summary>
        [JsonPropertyName("shippingAddress")]
        public Address ShippingAddress { get;  } = new();

        /// <summary>
        /// Gets or sets billing address.
        /// </summary>
        [JsonPropertyName("billingAddress")]
        public Address BillingAddress { get; } = new();

        /// <summary>
        /// Gets or sets charge amount.
        /// </summary>
        [JsonPropertyName("chargeAmount")]
        public Price ChargeAmount { get; }

        /// <summary>
        /// Gets or sets total order amount.
        /// </summary>
        [JsonIgnore]
        public Price TotalOrderAmount { get; } = new();

        [JsonPropertyName("totalOrderAmount")]
        public Price? TotalOrderAmountRaw => TotalOrderAmount.IsEmpty ? null : TotalOrderAmount;
}