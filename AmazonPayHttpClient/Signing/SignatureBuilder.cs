namespace AmazonPayHttpClient;

internal class SignatureBuilder
{
	private readonly Uri _url;
	private readonly IHasher _hash;
	private readonly ISigner _signer;
	private readonly string _method;
	private readonly string _body;
	private readonly IEnumerable<KeyValuePair<string, IEnumerable<string>>> _headers;

	public SignatureBuilder(Uri? url, string? body,  IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers, 
		IHasher hash, ISigner signer, string method = "GET")
	{
		_url = url ?? throw new ArgumentNullException(nameof(url));
		_hash = hash;
		_signer = signer;
		_method = method;
		_body = body ?? string.Empty;
		_headers = headers;
	}


	public Task<(byte[] signature, string headers)> Build()
	{
		var (canonicalRequest, signedHeaders) = BuildCanonicalRequest();
		var stringToSign = BuildStringToSign(canonicalRequest);
		var sign = BuildSign(stringToSign);

		return Task.FromResult((sign, signedHeaders));
	}

	private (string request, string signedHeaders)  BuildCanonicalRequest()
	{
		var builder = new RequestForSignBuilder(
			_url,
			_body,
			_headers,
			_hash,
			_method
			);
		
		return builder.Build();
	}

	private string BuildStringToSign(string request)
	{
		var builder = new StringToSignBuilder(_hash);
		return builder.Build(request);
	}

	private byte[] BuildSign(string content)
	{
		return _signer.Sign(content);
	}
}