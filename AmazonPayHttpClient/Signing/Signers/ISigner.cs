namespace AmazonPayHttpClient;

public interface ISigner
{
	byte[] Sign(byte[] content);
}

/// <summary>
/// Should make a RSASSA-PSS with sha 256 signature.
/// </summary>
public interface ISigner<TPrivateKeyProvider>: ISigner
	where TPrivateKeyProvider: class, IPrivateKeyProvider

{
}