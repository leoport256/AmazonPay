using AmazonPayHttpClient;
using Microsoft.Extensions.Configuration;

namespace AmazonPayConfigurationKeyProviders;

public interface ISamplePrivateKeyProvider: IPrivateKeyProvider
{
	
}

public sealed class PrivateKeyConfigurationProvider: ISamplePrivateKeyProvider
{
	private readonly PrivateKeyProviderFromFile _privateKeyProvider;

	public PrivateKeyConfigurationProvider(IConfiguration configuration)
	{
		var path = configuration.GetValue<string>("privateKey") ??
					throw new InvalidCastException("privateKey path should be set.");
		_privateKeyProvider = new PrivateKeyProviderFromFile(path);
	}

	public char[]? Provide()
	{
		return _privateKeyProvider.Provide();
	}
}