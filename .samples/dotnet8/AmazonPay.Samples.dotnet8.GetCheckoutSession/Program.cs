
using System.Net;
using AmazonPayConfigurationKeyProviders;
using AmazonPayConfigurationKeyProviders.ServiceCollections;
using AmazonPayHttpClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

var configuration = new ConfigurationBuilder().
	AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
	Build();

serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.AddSampleKeyProviders();

var serviceProvider = serviceCollection.BuildServiceProvider();

var client = AmazonHttpClientFactory.CreateForUnitedStates(
	serviceProvider.GetRequiredService<ISamplePrivateKeyProvider>(),
	serviceProvider.GetRequiredService<ISamplePublicKeyProvider>()
);


while (true)
{
	Console.WriteLine("Enter checkout session id:");
	var checkoutSessionId = Console.ReadLine();

	using var response = await client.GetAsync($"/v2/checkoutSessions/{checkoutSessionId}");
	
	Console.WriteLine($"RawRequest:");
	Console.WriteLine($"{response.RequestMessage}");
	
	Console.WriteLine($"RawResponse:");
	var content = await getContentAsString(response.Content);
	Console.WriteLine(content);

	Console.WriteLine($"Success: {response.StatusCode == HttpStatusCode.OK}");

	Console.WriteLine(System.Environment.NewLine);
}

async Task<string> getContentAsString(HttpContent content)
{
	var headers = content.Headers.ToString();
	var contentAsString = await content.ReadAsStringAsync();

	return $"{headers}{Environment.NewLine}{contentAsString}";
}