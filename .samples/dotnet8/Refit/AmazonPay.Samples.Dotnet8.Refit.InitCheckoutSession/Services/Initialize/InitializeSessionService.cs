using System.Text.Json;
using AmazonPayConfigurationKeyProviders;
using AmazonPayHttpClient;
using AmazonPayHttpClient.Contracts;

namespace AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Initialize;

internal sealed class InitializeSessionService: IInitializeSessionService
{
	private readonly IAmazonConfiguration _configuration;
	private readonly ISignatureClient<PrivateKeyConfigurationProvider> _payloadSigner;

	public InitializeSessionService(IAmazonConfiguration configuration, PrivateKeyConfigurationProvider privateKeyProvider)
	{
		_configuration = configuration;
		_payloadSigner = SignatureClientFactory.Create(privateKeyProvider);
	}

	public Task<Result> Initialize(Request request,
		CancellationToken cancellationToken)
	{
		var checkoutRequest =
			new CreateCheckoutSessionRequest(checkoutReviewReturnUrl: request.ReviewRedirectUrl,
				storeId: _configuration.StoreId)
			{
				PaymentDetails =
				{
					PaymentIntent = PaymentIntent.Confirm,
					ChargeAmount = { Amount = request.Amount, CurrencyCode = Currency.USD },
					TotalOrderAmount = { Amount = request.Amount, CurrencyCode = Currency.USD },
					CanHandlePendingAuthorization = false
				},
				MerchantMetadata =
				{
					CustomInformation = Guid.NewGuid().ToString("N"),
					MerchantReferenceId = Guid.NewGuid().ToString("N"),
				}
			};


		var payload = JsonSerializer.Serialize(checkoutRequest, AmazonPayJsonSerializerOptions.JsonSerializerOptions);
		var sign =_payloadSigner.SignAsBase64(payload);

		return Task.FromResult(new Result(payload, sign));
	}
}