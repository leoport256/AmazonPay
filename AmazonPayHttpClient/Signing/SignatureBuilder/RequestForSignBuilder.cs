using System.Text;

namespace AmazonPayHttpClient;

internal sealed class RequestForSignBuilder
{
	private const string LineSeparator = "\n";
	
	private readonly Uri _url;
	private readonly IHasher _hash;
	private readonly string _method;
	private readonly string _body;
	private readonly Dictionary<string, IEnumerable<string>> _headers;

	private string SignedHeaders => string.Join(";", _headers.Keys);

	public RequestForSignBuilder(Uri? url, string? body, IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers,
		IHasher hash, string method = "GET")
	{
		_headers = headers.
			OrderBy(s => s.Key).
			ToDictionary(s => s.Key.ToLower(), s => s.Value);
		_url = url ?? throw new ArgumentNullException(nameof(url));
		_hash = hash;
		_method = method;
		_body = body ?? string.Empty;
	}

	public (string request, string signedHeaders) Build()
	{
		return (BuildCanonicalRequest(), SignedHeaders);
	}
	
	private string BuildCanonicalRequest()
	{
		var builder = new StringBuilder();

		builder.Append(_method).
			Append(LineSeparator).
			Append(_url.AbsolutePath).
			Append(LineSeparator).
			Append(LineSeparator);
		
		AppendHeaders(builder).
			Append(LineSeparator).
			Append(HashBody());

		return builder.ToString();
	}
	
	private StringBuilder AppendHeaders(StringBuilder builder)
	{
		foreach (var key  in _headers.Keys)
		{
			var values = _headers[key];
			var value = string.Join(",", values);
			builder.Append($"{key}:{value}").Append(LineSeparator);
		}
		
		builder.
			Append(LineSeparator).
			Append(SignedHeaders);

		return builder;
	}

	private string HashBody()
	{
		return  _hash.FormattedHash(_body);
	}
	
}