using System.Text;

namespace AmazonPayHttpClient;

internal static  class StringToSignBuilder
{
	private const string LineSeparator = "\n";
	private const string AmazonSignatureAlgorithm = "AMZN-PAY-RSASSA-PSS-V2";

	public static string Build(IHasher hasher, string request)
	{
		var hashed = hasher.FormattedHash(request);

		var stringToSignBuilder = new StringBuilder();
		
		// TODO: I think this is fixed length string
		stringToSignBuilder.
			Append(AmazonSignatureAlgorithm).
			Append(LineSeparator).
			Append(hashed);

		return stringToSignBuilder.ToString();
	}
}