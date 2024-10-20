
using System.Text;

namespace AmazonPayHttpClient;

internal sealed partial class SignatureBuilder
{
	private const string LineSeparator = "\n";

	public (string request, string signedHeaders) CreateCanonicalRequest()
	{
		var signedHeaders = string.Join(";", _headerKeys);
		return (BuildCanonicalRequest(signedHeaders), signedHeaders);
	}
	
	private string BuildCanonicalRequest(string signedHeaders)
	{
		
		var builder = new StringBuilder();

		builder.Append(_method).
			Append(LineSeparator).
			Append(_url.AbsolutePath).
			Append(LineSeparator).
			Append(LineSeparator);
		
		AppendHeaders(builder, _headerKeys, _headerValues, signedHeaders).
			Append(LineSeparator).
			Append(_hash.FormattedHash(_body));

		return builder.ToString();
	}
	
	private StringBuilder AppendHeaders(StringBuilder builder, 
		string[] headerKeys, string[] headerValues, string signedHeaders)
	{
		for(var i = 0; i < Math.Min(headerKeys.Length, headerValues.Length); ++i)
		{
			builder.Append($"{headerKeys[i]}:{headerValues[i]}{LineSeparator}");
		}
		
		builder.
			Append(LineSeparator).
			Append(signedHeaders);

		return builder;
	}
}