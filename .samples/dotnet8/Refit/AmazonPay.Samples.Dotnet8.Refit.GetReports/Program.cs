using System.Net;
using System.Text.Json;
using AmazonPay.Samples.Dotnet8.Refit.GetReports;
using AmazonPayConfigurationKeyProviders;
using AmazonPayHttpClient.Contracts;
using AmazonPayHttpClient.Refit;
using AmazonPayHttpClient.ServiceCollections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

var serviceCollection = new ServiceCollection();

var configuration = new ConfigurationBuilder().
	AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
	Build();

serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.AddTransient<LogMiddleware>();

var clientBulder = serviceCollection.
	AddAmazonPay<PrivateKeyConfigurationProvider, PublicKeyConfigurationProvider>().
	AddAmazonPayRefitClientForUnitedStates<IUnitedStatesAmazonPayClient, PrivateKeyConfigurationProvider,
		PublicKeyConfigurationProvider>(null).
	AddHttpMessageHandler<LogMiddleware>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var client = serviceProvider.GetRequiredService<IUnitedStatesAmazonPayClient>();
//while (true)
{
	Console.WriteLine("Getting reports:");

	using var response = await client.GetReports(
		createdSince: DateTime.UtcNow.AddMonths(-1),
		createdUntil: DateTime.UtcNow,
		nextToken: null,
		pageSize: 10,
		processingStatuses: [ProcessingStatus.COMPLETED, ProcessingStatus.FAILED],
		reportTypes:
		[
			ReportTypes._GET_FLAT_FILE_OFFAMAZONPAYMENTS_REFUND_DATA_,
			ReportTypes._GET_FLAT_FILE_OFFAMAZONPAYMENTS_REFUND_DATA_
		]);
	
	Console.WriteLine($"RawRequest:");
	Console.WriteLine($"{response.RequestMessage}");
	
	Console.WriteLine($"RawResponse:");
	var content = getContentAsString(response);
	
	Console.WriteLine($"{content}");

	Console.WriteLine($"Success: {response.StatusCode == HttpStatusCode.OK}");

	Console.WriteLine(System.Environment.NewLine);
}

string getContentAsString<T>(ApiResponse<T> response)
{
	if (response.Error is not null)
	{
		return response.Error.Content ?? string.Empty;
	}

	if (response.Content is not null)
	{
		return JsonSerializer.Serialize(response.Content, new JsonSerializerOptions()
		{
			WriteIndented = true,
		});
	}

	return string.Empty;
}

public class LogMiddleware: DelegatingHandler
{
	public LogMiddleware(){
		
	}
	
	public LogMiddleware(HttpMessageHandler innerHandler) : base(innerHandler)
	{
	}
	
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var uri = request.RequestUri?.ToString() ??  string.Empty;
		Console.WriteLine(uri);
		return await base.SendAsync(request, cancellationToken);
	}
}