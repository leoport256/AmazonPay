using System.Security.Cryptography;

namespace AmazonPayHttpClient;

internal sealed class CertificateSigner<TPrivateKeyProvider>: ISigner<TPrivateKeyProvider> 
	where TPrivateKeyProvider : class, IPrivateKeyProvider
{
	private readonly RSA _rsa;
	private readonly HashAlgorithm _alg;


	public CertificateSigner(TPrivateKeyProvider privateKeyProvider)
	{
		_alg = CreateAlgorithm();
		
		_rsa = RSA.Create();
		_rsa.ImportFromPem(privateKeyProvider.Provide());
	}
	
	public byte[] Sign(byte[] content)
	{
		var hash = _alg.ComputeHash(content);

		var signature = _rsa.SignHash(hash, HashAlgorithmName.SHA256,
			RSASignaturePadding.Pss); 

		return signature;	
	}

	private HashAlgorithm CreateAlgorithm()
	{
		return SHA256.Create();
	}

	public void Dispose()
	{
		_alg.Dispose();
		_rsa.Dispose();
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