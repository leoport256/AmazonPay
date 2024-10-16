using AmazonPayHttpClient.Contracts.Newtonsoft;
using AmazonPayHttpClient.Refit.Newtonsoft;

namespace AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.InitCheckoutSession.Confirm;

internal sealed class ConfirmSessionService: IConfirmSessionService
{
	private readonly ILogger<ConfirmSessionService> _logger;
	private readonly IAmazonPayClient _client;

	public ConfirmSessionService(ILogger<ConfirmSessionService> logger, IUnitedStatesAmazonPayClient client)
	{
		_logger = logger;
		_client = client;
	}
	
	public async Task<Result> Confirm(Request request)
	{
		var sessionResponse = await _client.GetCheckoutSession(request.CheckoutSessionId);
		
		if (sessionResponse is { IsSuccessStatusCode: false})
		{
			_logger.LogError(sessionResponse.Error, "Something wrong with session: {sessionId}", request.CheckoutSessionId);
			throw new InvalidOperationException($"Something wrong with session: {request.CheckoutSessionId}");
		}

		var content = sessionResponse.Content;
		if (content?.PaymentDetails is null)
		{
			throw new InvalidOperationException($"Invalid checkout session {request.CheckoutSessionId}");
		}

		var completeCheckoutRequest = new CompleteCheckoutSessionRequest
		{
			ChargeAmount =
			{
				Amount = content.PaymentDetails.ChargeAmount.Amount,
				CurrencyCode = content.PaymentDetails.ChargeAmount.CurrencyCode
			},

			TotalOrderAmount =
			{
				Amount = content.PaymentDetails.TotalOrderAmount.Amount,
				CurrencyCode = content.PaymentDetails.TotalOrderAmount.CurrencyCode
			}
		};

		var checkoutSessionResponse = await _client.CompleteCheckoutSession(request.CheckoutSessionId,
			completeCheckoutRequest);

		if (!checkoutSessionResponse.IsSuccessStatusCode)
		{
			throw new InvalidOperationException(
				$"Something wrong with checkout session {request.CheckoutSessionId}");
		}

		var response = new Result(checkoutSessionResponse.Content.CheckoutSessionId,
			checkoutSessionResponse.Content.ChargePermissionId);
		
		return response;	
	}
}