using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AmazonPayHttpClient.ServiceCollections;

public static class ServiceCollectionsExtensions
{
	public static  IServiceCollection AddAmazonPay<TPrivateKeyProvider, TPublicKeyProvider>(this IServiceCollection services)
		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		services.TryAddScoped<IHasher, Sha256Hasher>();
		services.TryAddScoped<ISigner<TPrivateKeyProvider>, CertificateSigner<TPrivateKeyProvider>>();
		services.TryAddScoped<TPrivateKeyProvider, TPrivateKeyProvider>();
		services.TryAddScoped<TPublicKeyProvider, TPublicKeyProvider>();
		services.TryAddScoped<ISignatureClient<TPrivateKeyProvider>, SignatureClient<TPrivateKeyProvider>>();

		services.TryAddTransient<AmazonPayIdempotencyMiddleware>();
		services.TryAddTransient<AmazonPayPrepareContentMiddleware>();
		//services.TryAddTransient<AmazonPayFixContentMiddleware>();
		services.TryAddTransient<AmazonPayMiddleware>();
		services.TryAddTransient<AmazonPaySignMiddleware<TPrivateKeyProvider, TPublicKeyProvider>>();

		return services;
	}

	public static IHttpClientBuilder ConfigureAmazonPayForUnitedStates<TPrivateKeyProvider, TPublicKeyProvider>(
		this IHttpClientBuilder builder)
		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return builder.ConfigureAmazonPay<TPrivateKeyProvider, TPublicKeyProvider>(Region.UnitedStates);
	}
	
	public static IHttpClientBuilder ConfigureAmazonPayForEurope<TPrivateKeyProvider, TPublicKeyProvider>(
		this IHttpClientBuilder builder)
		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return builder.ConfigureAmazonPay<TPrivateKeyProvider, TPublicKeyProvider>(Region.Europe);
	}
	
		
	public static IHttpClientBuilder ConfigureAmazonPayForJapan<TPrivateKeyProvider, TPublicKeyProvider>(
		this IHttpClientBuilder builder)
		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return builder.ConfigureAmazonPay<TPrivateKeyProvider, TPublicKeyProvider>(Region.Japan);
	}


	private static IHttpClientBuilder ConfigureAmazonPay<TPrivateKeyProvider, TPublicKeyProvider>(
		this IHttpClientBuilder builder, 
		Region region)
		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return builder.
			AddHttpMessageHandler<AmazonPayIdempotencyMiddleware>().
			AddHttpMessageHandler<AmazonPayPrepareContentMiddleware>().
			//AddHttpMessageHandler<AmazonPayFixContentMiddleware>().
			AddHttpMessageHandler<AmazonPayMiddleware>().
			AddHttpMessageHandler<AmazonPaySignMiddleware<TPrivateKeyProvider, TPublicKeyProvider>>().
			ConfigureHttpClient(client =>
			{
				client.BaseAddress = new Uri(region.ToUrl());
				client.DefaultRequestHeaders.Remove("x-amz-pay-region");
				client.DefaultRequestHeaders.Add("x-amz-pay-region", region.ToShortForm());
			});
	}
}

	// internal IHttpClientBuilder ConfigureAmazonPay(this IHttpClientBuilder builder)
	// {
	//
	// }
// }