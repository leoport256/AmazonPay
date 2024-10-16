namespace AmazonPayHttpClient;


public sealed class NativePublicKeyProvider : IPublicKeyProvider
{
	public NativePublicKeyProvider(string? key)
	{
		PublicKey = key ?? throw new ArgumentNullException(nameof(key));
	}

	public string PublicKey { get; }
}