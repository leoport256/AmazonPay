using System.Security.Cryptography;

namespace AmazonPayHttpClient;

internal sealed class Sha256Hasher: IHasher
{
	public byte[] Hash(byte[] bytes)
	{
		var hash = SHA256.HashData(bytes);
		return hash;	
	}
}