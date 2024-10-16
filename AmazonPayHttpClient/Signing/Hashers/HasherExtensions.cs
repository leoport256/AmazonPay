using System.Text;

namespace AmazonPayHttpClient;

internal static class HasherExtensions
{
	public static string FormattedHash(this IHasher hasher, string content)
	{
		var hashValue = new StringBuilder();
		
		var bytes = hasher.Hash(content);
		foreach (Byte b in bytes)
		{
			hashValue.Append(b.ToString("x2"));
		}

		return hashValue.ToString();
	}
}