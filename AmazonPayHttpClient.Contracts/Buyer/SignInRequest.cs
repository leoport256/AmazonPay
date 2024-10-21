using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class SignInRequest
{
    /// <summary>
    /// Initializes a new instance of the SignInRequest class.
    /// </summary>
    /// <param name="signInReturnUrl">Checkout review URL provided by the merchant. Amazon Pay will redirect to this URL after the buyer selects their preferred payment instrument and shipping address.</param>
    /// <param name="storeId">Store ID as defined in Seller Central.</param>
    public SignInRequest(string signInReturnUrl, string storeId)
    {
        SignInReturnUrl = signInReturnUrl;
        StoreId = storeId;
    }

    /// <summary>
    /// Initializes a new instance of the SignInRequest class.
    /// </summary>
    /// <param name="signInReturnUrl">Checkout review URL provided by the merchant. Amazon Pay will redirect to this URL after the buyer selects their preferred payment instrument and shipping address.</param>
    /// <param name="storeId">Store ID as defined in Seller Central.</param>
    /// <param name="signInScopes"></param>
    public SignInRequest(string signInReturnUrl, string storeId, params SignInScope[] signInScopes) : this(signInReturnUrl, storeId)
    {
        SignInScopes = signInScopes;
    }

    /// <summary>
    /// Login with Amazon client ID. Do not use the application ID.
    /// </summary>
    [JsonPropertyName("storeId")]
    public string StoreId { get; }

    /// <summary>
    /// Amazon Pay will redirect to this URL after the buyer signs in.
    /// </summary>
    [JsonPropertyName("signInReturnUrl")]
    public string SignInReturnUrl { get; }

    /// <summary>
    /// The buyer details that you're requesting access for.
    /// </summary>
    /// <remarks>
    /// Note that Amazon Pay will always return BuyerId even if no values are set for this parameter.
    /// </remarks>
    [JsonPropertyName("signInScopes")]
    public SignInScope[]? SignInScopes { get; set; }
}