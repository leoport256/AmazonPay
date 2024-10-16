using System.Security.Cryptography;

namespace AmazonPayHttpClient;

internal sealed class CertificateSigner<TPrivateKeyProvider>: ISigner<TPrivateKeyProvider> 
	where TPrivateKeyProvider : class, IPrivateKeyProvider
{
	private readonly TPrivateKeyProvider _privateKeyProvider;

	public CertificateSigner(TPrivateKeyProvider privateKeyProvider)
	{
		_privateKeyProvider = privateKeyProvider;
	}
	
	public byte[] Sign(byte[] content)
	{
		// TODO: Maybe one time?
		using var alg = CreateAlgorithm();
		var hash = alg.ComputeHash(content);

		var privateKey = _privateKeyProvider.Provide();
		using var  rsa = RSA.Create();
		rsa.ImportFromPem(privateKey);

		var signature = rsa.SignHash(hash, HashAlgorithmName.SHA256,
			RSASignaturePadding.Pss); 

		return signature;	
	}

	private HashAlgorithm CreateAlgorithm()
	{
		return SHA256.Create();
	}
}

internal static class CertificateSignerExtensions
{
	public static byte[] Sign<TPrivateKeyProvider>(this ISigner<TPrivateKeyProvider> signer, string content)
		where TPrivateKeyProvider : class, IPrivateKeyProvider
	{
		return signer.Sign(System.Text.Encoding.UTF8.GetBytes(content));
	}
	
	public static byte[] Sign(this ISigner signer, string content)
	{
		return signer.Sign(System.Text.Encoding.UTF8.GetBytes(content));
	}
}