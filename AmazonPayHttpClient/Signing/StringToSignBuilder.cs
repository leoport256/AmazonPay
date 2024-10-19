using System.Text;

namespace AmazonPayHttpClient;

internal static  class StringToSignBuilder
{
	private const string LineSeparator = "\n";
	private const string AmazonSignatureAlgorithm = "AMZN-PAY-RSASSA-PSS-V2";
	private const string AmazonSignatureAlgorithmWithNewLine = $"{AmazonSignatureAlgorithm}{LineSeparator}";

	public static string Build(IHasher hasher, string request)
	{
		var hashed = hasher.FormattedHash(request);
		return string.Concat(AmazonSignatureAlgorithmWithNewLine.AsSpan(), hashed.AsSpan());
	}
}