using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CreateCheckoutSessionRequest : UpdateCheckoutSessionRequest
{

	/// <summary>
	/// Initializes a new instance of the CreateCheckoutSessionRequest class.
	/// </summary>
	/// <param name="checkoutReviewReturnUrl">Checkout review URL provided by the merchant. Amazon Pay will redirect to this URL after the buyer selects their preferred payment instrument and shipping address.</param>
	/// <param name="storeId">Store ID as defined in Seller Central.</param>
	public CreateCheckoutSessionRequest(string checkoutReviewReturnUrl, string storeId)
	{
		WebCheckoutDetails.CheckoutReviewReturnUrl = checkoutReviewReturnUrl;
		StoreId = storeId;
	}

	/// <summary>
	/// Initializes a new instance of the CreateCheckoutSessionRequest class.
	/// </summary>
	/// <param name="checkoutReviewReturnUrl">Checkout review URL provided by the merchant. Amazon Pay will redirect to this URL after the buyer selects their preferred payment instrument and shipping address.</param>
	/// <param name="storeId">Store ID as defined in Seller Central.</param>
	/// <param name="scopes">Scopes passed by merchant to request buyer data</param>
	public CreateCheckoutSessionRequest(string checkoutReviewReturnUrl, string storeId, CheckoutSessionScope[] scopes)
	{
		WebCheckoutDetails.CheckoutReviewReturnUrl = checkoutReviewReturnUrl;
		StoreId = storeId;
		CheckoutSessionScope = scopes;
	}

	/// <summary>
	/// Login with Amazon client ID. Do not use the application ID.
	/// </summary>
	[JsonProperty("storeId")]
	public string? StoreId { get; }

	/// <summary>
	/// Specify shipping restrictions to prevent buyers from selecting unsupported addresses from their Amazon address book.
	/// </summary>
	[JsonProperty("deliverySpecifications")]
	public DeliverySpecifications DeliverySpecifications { get; } = new();

	/// <summary>
	/// Specify shipping address when CheckoutMode=ProcessOrder (Additional Payment Button, APB, mode).
	/// </summary>
	[JsonIgnore]
	public AddressDetails AddressDetails { get; } = new();

	/// <summary>
	/// Specify shipping address when CheckoutMode=ProcessOrder (Additional Payment Button, APB, mode).
	/// </summary>
	[JsonProperty("addressDetails")]
	public AddressDetails? AddressDetailsRaw => AddressDetails.IsEmpty ? null : AddressDetails;

	/// <summary>
	/// Checkout Session Scopes
	/// </summary>
	[JsonProperty("scopes")]
	public CheckoutSessionScope[] CheckoutSessionScope { get; } = [];

}