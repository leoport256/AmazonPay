namespace AmazonPayHttpClient;

public interface ISignatureClient<TPrivateKeyProvider>
	where TPrivateKeyProvider: class, IPrivateKeyProvider
{
	byte[] Sign(string source);
}