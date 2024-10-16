namespace AmazonPayHttpClient;

public interface ISigner: IDisposable
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