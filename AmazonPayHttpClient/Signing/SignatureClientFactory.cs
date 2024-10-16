namespace AmazonPayHttpClient;

public static class SignatureClientFactory
{
	public static ISignatureClient<TPrivateKeyProvider> Create<TPrivateKeyProvider>(
		TPrivateKeyProvider privateKeyProvider)
		where TPrivateKeyProvider : class, IPrivateKeyProvider
	{
		return new SignatureClient<TPrivateKeyProvider>(
			new Sha256Hasher(),
			new CertificateSigner<TPrivateKeyProvider>(privateKeyProvider));
	}
}