
using System.Text;

namespace AmazonPayHttpClient;

internal sealed partial class SignatureBuilder
{
	private const string LineSeparator = "\n";

	public (string request, string signedHeaders) CreateCanonicalRequest()
	{
		var headersForSign = _headers.
			OrderBy(s => s.Key).
			ToDictionary(s => s.Key.ToLower(), s => s.Value);

		var signedHeaders = string.Join(";", headersForSign.Keys);
		return (BuildCanonicalRequest(headersForSign, signedHeaders), signedHeaders);
	}
	
	private string BuildCanonicalRequest(Dictionary<string, IEnumerable<string>> headers, string signedHeaders)
	{
		
		var builder = new StringBuilder();

		builder.Append(_method).
			Append(LineSeparator).
			Append(_url.AbsolutePath).
			Append(LineSeparator).
			Append(LineSeparator);
		
		AppendHeaders(builder, headers, signedHeaders).
			Append(LineSeparator).
			Append(_hash.FormattedHash(_body));

		return builder.ToString();
	}
	
	private StringBuilder AppendHeaders(StringBuilder builder, 
		Dictionary<string, IEnumerable<string>> headers, string signedHeaders)
	{
		foreach (var key  in headers.Keys)
		{
			var values = headers[key];
			var value = string.Join(",", values);
			builder.Append($"{key}:{value}").Append(LineSeparator);
		}
		
		builder.
			Append(LineSeparator).
			Append(string.Join(";", headers.Keys));

		return builder;
	}
}