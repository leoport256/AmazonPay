using System.Text;

namespace AmazonPayHttpClient;

public interface IHasher
{
	byte[] Hash(byte[] bytes);
}

public static class HasherExtension
{
	public static byte[] Hash(this IHasher hasher, string content)
	{
		var bytes = Encoding.UTF8.GetBytes(content);
		return hasher.Hash(bytes);
	}
}