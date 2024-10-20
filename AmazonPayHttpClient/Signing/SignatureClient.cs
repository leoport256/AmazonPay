namespace AmazonPayHttpClient;

internal sealed class SignatureClient<TPrivateKeyProvider>: ISignatureClient<TPrivateKeyProvider>
	where TPrivateKeyProvider: class, IPrivateKeyProvider
{
	private readonly IHasher _hasher;
	private readonly ISigner<TPrivateKeyProvider> _signer;

	public SignatureClient(IHasher hasher, ISigner<TPrivateKeyProvider> signer)
	{
		_hasher = hasher;
		_signer = signer;
	}

	public byte[] Sign(string source)
	{
		return BuildSign(BuildStringToSign(source));
	}
	
	private string BuildStringToSign(string request)
	{
		return StringToSignBuilder.Build(_hasher, request);
	}

	private byte[] BuildSign(string content)
	{
		return _signer.Sign(content);
	}	
}

public static  class SignatureClientExtensions
{
	public static string SignAsBase64<TPrivateKeyProvider>(this  ISignatureClient<TPrivateKeyProvider> source,
		string content)
		where TPrivateKeyProvider: class, IPrivateKeyProvider

	{
		return Convert.ToBase64String(source.Sign(content));
	}
}