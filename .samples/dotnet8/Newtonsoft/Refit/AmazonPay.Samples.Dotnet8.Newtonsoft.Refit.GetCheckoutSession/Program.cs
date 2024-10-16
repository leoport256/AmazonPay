using System.Net;
using System.Text.Json;
using AmazonPayConfigurationKeyProviders;
using AmazonPayHttpClient.Refit.Newtonsoft;
using AmazonPayHttpClient.ServiceCollections;
using AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.GetCheckoutSession;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

var serviceCollection = new ServiceCollection();

var configuration = new ConfigurationBuilder().
	AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
	Build();

serviceCollection.AddSingleton<IConfiguration>(configuration);

var clientBulder = serviceCollection.
	AddAmazonPay<PrivateKeyConfigurationProvider, PublicKeyConfigurationProvider>().
	AddAmazonPayRefitClientForUnitedStates<IUnitedStatesAmazonPayClient, PrivateKeyConfigurationProvider,
		PublicKeyConfigurationProvider>(null);

var serviceProvider = serviceCollection.BuildServiceProvider();

var client = serviceProvider.GetRequiredService<IUnitedStatesAmazonPayClient>();
while (true)
{
	Console.WriteLine("Enter checkout session id:");
	var checkoutSessionId = Console.ReadLine();
	if (checkoutSessionId is null)
		continue;
	
	using var response = await client.GetCheckoutSession(checkoutSessionId);
	
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