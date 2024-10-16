namespace AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.InitCheckoutSession.Initialize;

internal interface IInitializeSessionService
{
	Task<Result> Initialize(Request request,
		CancellationToken cancellationToken);
}