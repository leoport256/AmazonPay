namespace AmazonPayHttpClient;


public sealed class NativePrivateKeyProvider : IPrivateKeyProvider
{
	private readonly string _privateKey; 

	public NativePrivateKeyProvider(string? key)
	{
		_privateKey = key ?? throw new ArgumentNullException(nameof(key));
	}
	
	public char[]? Provide()
	{
		return _privateKey.ToCharArray();
	}
}