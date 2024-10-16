using System.Text.Json.Serialization;
using AmazonPayConfigurationKeyProviders;
using AmazonPayConfigurationKeyProviders.ServiceCollections;
using AmazonPayHttpClient.Refit;
using AmazonPayHttpClient.ServiceCollections;
using AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession;
using AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Confirm;
using AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Initialize;
using AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Review;
using Microsoft.AspNetCore.Mvc;
using Request = AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Initialize.Request;

var builder = WebApplication.CreateBuilder(args);
builder.
	Services.
	AddRazorPages();

builder.
	Services.
	AddAmazonPay<PrivateKeyConfigurationProvider, PublicKeyConfigurationProvider>().
	AddSingleton<IAmazonConfiguration, AmazonConfiguration>().
	AddTransient<IInitializeSessionService, InitializeSessionService>().
	AddTransient<IConfirmSessionService, ConfirmSessionService>().
	AddTransient<IReviewSessionService, ReviewSessionCommand>().
	AddSampleKeyProviders().
	AddAmazonPayRefitClientForUnitedStates<IUnitedStatesAmazonPayClient, PrivateKeyConfigurationProvider,
		PublicKeyConfigurationProvider>(null);


var app = builder.Build();

app.MapGet("/", () => Microsoft.AspNetCore.Http.Results.Redirect("/Pay"));

app.MapPost("/amazon/init", async (
	[FromBody]AmazonInitRequest request, 
	HttpRequest httpRequest,
	IInitializeSessionService service) =>
{
	var payloadWithSign = await service.Initialize(
		new Request(
			request.Amount, 
			$"https://{httpRequest.Host}{httpRequest.PathBase}/amazon/review"), CancellationToken.None);
	return Microsoft.AspNetCore.Http.Results.Ok(payloadWithSign);
});

app.MapGet("/amazon/review", async (
	[FromQuery(Name="amazonCheckoutSessionId")] string checkoutSessionId, 
	HttpRequest httpRequest,

	IReviewSessionService service
	) =>
{
	var result = await service.Review(new AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Review.Request(
		$"https://{httpRequest.Host}{httpRequest.PathBase}/amazon/confirm",
		checkoutSessionId));
	return Microsoft.AspNetCore.Http.Results.Redirect(result.RedirectUrl);
});
app.MapGet("/amazon/confirm", async (
	[FromQuery(Name="amazonCheckoutSessionId")] string checkoutSessionId, 
	IConfirmSessionService service	
	
	) =>
{
	var resut = await service.Confirm(new AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Confirm.Request(checkoutSessionId));
	return Microsoft.AspNetCore.Http.Results.Redirect($"/Pay?checkoutSessionId={checkoutSessionId}&chargePermissionId={resut.ChargePermissionId}");
});


app.MapRazorPages();

app.Run();

internal sealed record AmazonInitRequest([property: JsonPropertyName("amount")] decimal Amount);
