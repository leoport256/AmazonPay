using AmazonPayHttpClient.Contracts;
using AmazonPayHttpClient.Refit;

namespace AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Review;

internal sealed class ReviewSessionCommand: IReviewSessionService
{
	private readonly ILogger<ReviewSessionCommand> _logger;
	private readonly IAmazonPayClient _client;

	public ReviewSessionCommand(ILogger<ReviewSessionCommand> logger, IUnitedStatesAmazonPayClient client)
	{
		_logger = logger;
		_client = client;
	}
	public async Task<Result> Review(Request request)
	{
		var session = await _client.GetCheckoutSession(request.CheckoutSessionId);

		if (session  is { IsSuccessStatusCode: false})
		{
			_logger.LogError(session.Error, "Something wrong with session: {sessionId}", request.CheckoutSessionId);
			throw new InvalidOperationException($"Something wrong with session: {request.CheckoutSessionId}");
		}

		var updateSessionRequest = new UpdateCheckoutSessionRequest
		{
			WebCheckoutDetails = { CheckoutResultReturnUrl = request.ConfirmRedirectUrl }
		};

		var updatedSession = await _client.UpdateCheckoutSession(request.CheckoutSessionId, updateSessionRequest);
		if (updatedSession  is { IsSuccessStatusCode: false})
		{
			_logger.LogError(session.Error, "Something wrong with session: {sessionId}", request.CheckoutSessionId);
			throw new InvalidOperationException($"Something wrong with session: {request.CheckoutSessionId}");
		}
		
		session = await _client.GetCheckoutSession(request.CheckoutSessionId);
		
		if (session  is { IsSuccessStatusCode: false})
		{
			_logger.LogError(session.Error, "Something wrong with session: {sessionId}", request.CheckoutSessionId);
		}

		var redirectUrl = session.Content?.WebCheckoutDetails?.AmazonPayRedirectUrl
						?? throw new InvalidOperationException(
							$"Something wrong with session: {request.CheckoutSessionId}");

		return new Result(redirectUrl);
	}

	private void ThrowOnSuccessStatusCode(string  checkoutSessionId)
	{
		throw new InvalidOperationException($"Session {checkoutSessionId} does not found");

	}

}