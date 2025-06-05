
using System.Text;

namespace AmazonPayHttpClient;

internal sealed partial class SignatureBuilder
{
	private const string LineSeparator = "\n";

	private string BuildCanonicalRequest()
	{
		
		var builder = new StringBuilder(512);

		builder.Append(_method).
			Append(LineSeparator).
			Append(_url.AbsolutePath).
			Append(LineSeparator);
		AppendQueryString(builder, _url).
			Append(LineSeparator);
		
		AppendHeaders(builder, _headerKeys, _headerValues).
			Append(LineSeparator).
			Append(_hash.FormattedHash(_body));

		return builder.ToString();
	}
	
	private StringBuilder AppendHeaders(StringBuilder builder, 
		string[] headerKeys, string[] headerValues)
	{
		for(var i = 0; i < Math.Min(headerKeys.Length, headerValues.Length); ++i)
		{
			builder.Append(headerKeys[i]).
				Append(':').
				Append(headerValues[i]).
				Append(LineSeparator);
		}
		
		builder.
			Append(LineSeparator).
			Append(_joinedHeaderKeys);

		return builder;
	}
	
	private StringBuilder AppendQueryString(StringBuilder builder, Uri url)
	{
		if (url.Query.Length <= 1)
		{
			return builder;
		}

		var query = url.Query[1..];
		return builder.Append(query);
	}
}