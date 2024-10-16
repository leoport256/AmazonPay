namespace AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Confirm;

internal interface IConfirmSessionService
{
	Task<Result> Confirm(Request request);
}