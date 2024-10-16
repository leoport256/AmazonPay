using AmazonPayHttpClient.Contracts;
using AmazonPayHttpClient.ServiceCollections;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AmazonPayHttpClient.Refit;

public static class  AmazonPayClient
{
	public static IHttpClientBuilder AddAmazonPayRefitClientForUnitedStates<TClient, TPrivateKeyProvider, TPublicKeyProvider>(this IServiceCollection services, RefitSettings? settings)
		where TClient: class, IAmazonPayClient

		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return services.
			AddRefitClient<TClient>(MakeRefitSettings(settings)).
			ConfigureAmazonPayForUnitedStates<TPrivateKeyProvider, TPublicKeyProvider>();
	}
	
	public static IHttpClientBuilder AddAmazonPayRefitClientForJapan<TClient, TPrivateKeyProvider, TPublicKeyProvider>(this IServiceCollection services, RefitSettings? settings)
		where TClient: class, IAmazonPayClient

		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return services.
			AddRefitClient<TClient>(MakeRefitSettings(settings)).
			ConfigureAmazonPayForJapan<TPrivateKeyProvider, TPublicKeyProvider>();
	}
	
	public static IHttpClientBuilder AddAmazonPayRefitClientForEurope<TClient, TPrivateKeyProvider, TPublicKeyProvider>(this IServiceCollection services, RefitSettings? settings)
		where TClient: class, IAmazonPayClient

		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		return services.
			AddRefitClient<TClient>(MakeRefitSettings(settings)).
			ConfigureAmazonPayForEurope<TPrivateKeyProvider, TPublicKeyProvider>();
	}
	
	public static TClient ForEurope<TClient, TPrivateKeyProvider, TPublicKeyProvider>(
		TPrivateKeyProvider privateKeyProvider, 		
		TPublicKeyProvider publicKeyProvider, 
		RefitSettings? settings = null,
		HttpMessageHandler? baseHandler = null)
		where TClient: class, IAmazonPayClient

		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{

		var httpClient = AmazonHttpClientFactory.CreateForEurope(privateKeyProvider, publicKeyProvider, baseHandler);
		
		settings ??= new RefitSettings();
		return RestService.For<TClient>(httpClient, MakeRefitSettings(settings));
	}
	
	public static TClient FoJapan<TClient, TPrivateKeyProvider, TPublicKeyProvider>(
		TPrivateKeyProvider privateKeyProvider, 		
		TPublicKeyProvider publicKeyProvider, 
		RefitSettings? settings = null,
		HttpMessageHandler? baseHandler = null)
		where TClient: class, IAmazonPayClient

		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{

		var httpClient = AmazonHttpClientFactory.CreateForJapan(privateKeyProvider, publicKeyProvider, baseHandler);
		
		settings ??= new RefitSettings();
		return RestService.For<TClient>(httpClient, MakeRefitSettings(settings));
	}
	
	public static TClient FoUnitedStates<TClient, TPrivateKeyProvider, TPublicKeyProvider>(
		TPrivateKeyProvider privateKeyProvider, 		
		TPublicKeyProvider publicKeyProvider, 
		RefitSettings? settings = null,
		HttpMessageHandler? baseHandler = null)
		where TClient: class, IAmazonPayClient

		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{

		var httpClient = AmazonHttpClientFactory.CreateForUnitedStates(privateKeyProvider, publicKeyProvider, baseHandler);
		
		settings ??= new RefitSettings();
		return RestService.For<TClient>(httpClient, MakeRefitSettings(settings));
	}
	
	private static RefitSettings MakeRefitSettings(RefitSettings? settings)
	{
		settings ??= new RefitSettings();
		return new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(
				AmazonPayJsonSerializerOptions.JsonSerializerOptions),
			Buffered = settings.Buffered,
			CollectionFormat = settings.CollectionFormat,
			ExceptionFactory = settings.ExceptionFactory,
			UrlParameterFormatter = settings.UrlParameterFormatter,
			AuthorizationHeaderValueGetter = settings.AuthorizationHeaderValueGetter,
			HttpMessageHandlerFactory = settings.HttpMessageHandlerFactory,
			FormUrlEncodedParameterFormatter = settings.FormUrlEncodedParameterFormatter
		};
	}
}
