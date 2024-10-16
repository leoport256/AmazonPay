using AmazonPayHttpClient;
using Microsoft.Extensions.Configuration;

namespace AmazonPayConfigurationKeyProviders;

public interface ISamplePublicKeyProvider: IPublicKeyProvider
{
	
}

public class PublicKeyConfigurationProvider: ISamplePublicKeyProvider
{
	public string PublicKey { get; }

	public PublicKeyConfigurationProvider(IConfiguration configuration)
	{
		PublicKey = configuration.GetValue<string>("publicKey") ??
					throw new InvalidCastException("publicKey path should be set.");
	}
}