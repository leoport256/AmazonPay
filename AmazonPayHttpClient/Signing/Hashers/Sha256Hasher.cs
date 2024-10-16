using System.Security.Cryptography;
using System.Text;

namespace AmazonPayHttpClient;

internal sealed class Sha256Hasher: IHasher
{
	public byte[] Hash(string content)
	{
		var bytes = Encoding.UTF8.GetBytes(content);
		var hash = SHA256.HashData(bytes);
		return hash;	
	}
}