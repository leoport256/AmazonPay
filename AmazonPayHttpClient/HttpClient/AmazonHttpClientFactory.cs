namespace AmazonPayHttpClient;

public static class AmazonHttpClientFactory
{
	public static HttpClient CreateForUnitedStates<TPrivateKeyProvider, TPublicKeyProvider>(
		TPrivateKeyProvider privateKeyProvider,
		TPublicKeyProvider publicKeyProvider,
		HttpMessageHandler? baseHandler = null)
		where TPrivateKeyProvider : class, IPrivateKeyProvider
		where TPublicKeyProvider : class, IPublicKeyProvider
	{
		return Create(
			Region.UnitedStates,
			privateKeyProvider,
			publicKeyProvider,
			baseHandler);
	}

	public static HttpClient CreateForJapan<TPrivateKeyProvider, TPublicKeyProvider>(
		TPrivateKeyProvider privateKeyProvider,
		TPublicKeyProvider publicKeyProvider,
		HttpMessageHandler? baseHandler = null)
		where TPrivateKeyProvider : class, IPrivateKeyProvider
		where TPublicKeyProvider : class, IPublicKeyProvider
	{
		return Create(
			Region.Japan,
			privateKeyProvider,
			publicKeyProvider,
			baseHandler);
	}
	
	public static HttpClient CreateForEurope<TPrivateKeyProvider, TPublicKeyProvider>(
		TPrivateKeyProvider privateKeyProvider,
		TPublicKeyProvider publicKeyProvider,
		HttpMessageHandler? baseHandler = null)
		where TPrivateKeyProvider : class, IPrivateKeyProvider
		where TPublicKeyProvider : class, IPublicKeyProvider
	{
		return Create(
			Region.Europe,
			privateKeyProvider,
			publicKeyProvider,
			baseHandler);
	}
	
	internal  static  HttpClient Create<TPrivateKeyProvider, TPublicKeyProvider>(
		Region region, 
		TPrivateKeyProvider privateKeyProvider, 
		TPublicKeyProvider publicKeyProvider,
		HttpMessageHandler? baseHandler = null)
		where TPrivateKeyProvider: class, IPrivateKeyProvider
		where TPublicKeyProvider: class, IPublicKeyProvider
	{
		baseHandler ??= new HttpClientHandler();
		var handlers = new AmazonPayIdempotencyMiddleware(
			new AmazonPayPrepareContentMiddleware(
				//new AmazonPayFixContentMiddleware(
					new AmazonPayMiddleware(
						new AmazonPaySignMiddleware<TPrivateKeyProvider, TPublicKeyProvider>(
							publicKeyProvider,
							new Sha256Hasher(),
							new CertificateSigner<TPrivateKeyProvider>(privateKeyProvider),
							baseHandler
						))));

		return new HttpClient(handlers)
		{
			BaseAddress = new Uri(region.ToUrl()),
			DefaultRequestHeaders =
			{
				{ "x-amz-pay-region", region.ToShortForm() },
				//{ "Content-Type", "application/json" },
				{ "Accept", "application/json" }
			},
		};
	}
}