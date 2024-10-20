namespace AmazonPayHttpClient;

internal sealed partial class SignatureBuilder
{
	private readonly Uri _url;
	private readonly IHasher _hash;
	private readonly ISigner _signer;
	private readonly string _method;
	private readonly string _body;
	private readonly string[] _headerKeys;
	private readonly string[] _headerValues;

	public SignatureBuilder(Uri? url, string? body, 
		string[] headerKeys, string[] headerValues,
		IHasher hash, ISigner signer, string method = "GET")
	{
		_url = url ?? throw new ArgumentNullException(nameof(url));
		_headerKeys = headerKeys;
		_headerValues = headerValues;
		_hash = hash;
		_signer = signer;
		_method = method;
		_body = body ?? string.Empty;
	}


	public Task<(byte[] signature, string headers)> Build()
	{
		var (canonicalRequest, signedHeaders) = CreateCanonicalRequest();
		var stringToSign = BuildStringToSign(canonicalRequest);
		var sign = BuildSign(stringToSign);

		return Task.FromResult((sign, signedHeaders));
	}

	private string BuildStringToSign(string request)
	{
		return  StringToSignBuilder.Build(_hash, request);
	}

	private byte[] BuildSign(string content)
	{
		return _signer.Sign(content);
	}
}