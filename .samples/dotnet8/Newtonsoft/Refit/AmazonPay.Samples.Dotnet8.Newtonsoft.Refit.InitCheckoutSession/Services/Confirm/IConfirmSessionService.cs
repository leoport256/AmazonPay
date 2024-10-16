namespace AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.InitCheckoutSession.Confirm;

internal interface IConfirmSessionService
{
	Task<Result> Confirm(Request request);
}