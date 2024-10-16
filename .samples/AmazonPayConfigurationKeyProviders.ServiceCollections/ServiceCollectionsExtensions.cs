using Microsoft.Extensions.DependencyInjection;

namespace AmazonPayConfigurationKeyProviders.ServiceCollections;

public static class ServiceCollectionsExtensions
{
	public static IServiceCollection AddSampleKeyProviders(
		this IServiceCollection services)
	{
		services.AddSingleton<ISamplePrivateKeyProvider, PrivateKeyConfigurationProvider>();
		services.AddSingleton<ISamplePublicKeyProvider, PublicKeyConfigurationProvider>();
		
		// services.AddSingleton<PrivateKeyConfigurationProvider, PrivateKeyConfigurationProvider>();
		// services.AddSingleton<PublicKeyConfigurationProvider, PublicKeyConfigurationProvider>();
		
		return services;
	}
}