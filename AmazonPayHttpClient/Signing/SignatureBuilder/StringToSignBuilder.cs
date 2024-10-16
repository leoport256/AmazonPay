using System.Text;

namespace AmazonPayHttpClient;

internal sealed class StringToSignBuilder
{
	private readonly IHasher _hasher;
	private const string LineSeparator = "\n";
	private const string AmazonSignatureAlgorithm = "AMZN-PAY-RSASSA-PSS-V2";

	public StringToSignBuilder(IHasher hasher)
	{
		_hasher = hasher;
	}

	public string Build(string request)
	{
		var hashed = Hash(request);

		var stringToSignBuilder = new StringBuilder();
		
		stringToSignBuilder.
			Append(AmazonSignatureAlgorithm).
			Append(LineSeparator).
			Append(hashed);

		return stringToSignBuilder.ToString();
	}

	private string Hash(string str)
	{
		return _hasher.FormattedHash(str);
	}

}