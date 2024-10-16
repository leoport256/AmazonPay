namespace AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.InitCheckoutSession.Review;

internal interface IReviewSessionService
{
	Task<Result> Review(Request request);
}