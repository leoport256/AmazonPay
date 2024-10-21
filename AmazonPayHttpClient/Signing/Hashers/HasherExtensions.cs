using System.Diagnostics;

namespace AmazonPayHttpClient;

internal static class HasherExtensions
{
	public static string FormattedHash(this IHasher hasher, string content)
	{
		var bytes = hasher.Hash(content);

		return BytesToFormattedHex(bytes);
	}

	public static string BytesToFormattedHex(byte[] bytes)
	{
		Span<char> chars = stackalloc char[bytes.Length << 1]; 

		for (byte i = 0, ic = 0; i < bytes.Length; i++, ic += 2)
		{
			var b = bytes[i];
			var digit = (byte)(b & 0xF);
			chars[ic + 1] = (char)(digit + (digit < 10 ? (byte)'0' : (byte)'W'));
			b >>= 4;
			
			digit = (byte)(b & 0xF);
			chars[ic] = (char)(digit + (digit < 10 ? (byte)'0' : (byte)'W'));
		}

		return new string(chars);
	}
}
