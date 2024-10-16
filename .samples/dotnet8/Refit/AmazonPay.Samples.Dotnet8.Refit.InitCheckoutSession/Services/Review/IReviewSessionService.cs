namespace AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Review;

internal interface IReviewSessionService
{
	Task<Result> Review(Request request);
}