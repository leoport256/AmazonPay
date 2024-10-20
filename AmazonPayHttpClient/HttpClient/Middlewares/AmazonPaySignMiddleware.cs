using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("AmazonPayHttpClient.Tests")]

namespace AmazonPayHttpClient;

public class AmazonPaySignMiddleware<TPrivateKeyProvider, TPublicKeyProvider>: DelegatingHandler
	where TPrivateKeyProvider : class, IPrivateKeyProvider
	where TPublicKeyProvider: class, IPublicKeyProvider

{
	private readonly TPublicKeyProvider _publicKeyProvider;
	private readonly IHasher _hash;
	private readonly ISigner<TPrivateKeyProvider> _signer;

	private const string AmazonSignatureAlgorithm = "AMZN-PAY-RSASSA-PSS-V2";

	public AmazonPaySignMiddleware(TPublicKeyProvider publicKeyProvider, IHasher hash, ISigner<TPrivateKeyProvider> signer)
	{
		_publicKeyProvider = publicKeyProvider;
		_hash = hash;
		_signer = signer;
	}
	
	public AmazonPaySignMiddleware(TPublicKeyProvider publicKeyProvider, IHasher hash, ISigner<TPrivateKeyProvider> signer, HttpMessageHandler innerHandler) : base(innerHandler)
	{
		_publicKeyProvider = publicKeyProvider;
		_hash = hash;
		_signer = signer;
	}
	
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		await SignRequest(request);
		return await base.SendAsync(request, cancellationToken);
	}

	private async Task SignRequest(HttpRequestMessage request)
	{
		var (signature, signedHeaders) = await BuildSignature(request);

		request.Headers.Authorization = new AuthenticationHeaderValue(AmazonSignatureAlgorithm, BuildAuthorizationHeader(signature, signedHeaders));
	}
	
	private string BuildAuthorizationHeader(string signature, string signedHeaders)
	{
		var authorizationBuilder = new StringBuilder()
			.Append("PublicKeyId=").Append(_publicKeyProvider.PublicKey).Append(", ").Append("SignedHeaders=")
			.Append(signedHeaders)
			.Append(", Signature=").Append(signature);

		return authorizationBuilder.ToString();
	}

	private async Task<(string signature, string signedHeaders)> BuildSignature(HttpRequestMessage request)
	{
		var content = request.Content is not null
			? await request.Content.ReadAsStringAsync()
			: null;


		var (headersKeys, headersValues) = request.Method == HttpMethod.Post
			? RetrieveHeadersForPostRequest(request)
			: RetrieveHeaders(request);
		
		var builder = new SignatureBuilder(request.RequestUri, 
			content, 
			headersKeys,
			headersValues,
			_hash, 
			_signer,
			request.Method.Method);
		
		var (signBytes, signedHeaders) = await builder.Build();
		var signature = Convert.ToBase64String(signBytes);
		return (signature, signedHeaders);
	}
	
	private (string[] headers, string[] values) RetrieveHeaders(HttpRequestMessage request)
	{
		var values = new[]
		{
			"application/json", 
			"application/json", 
			GetHeader("x-amz-pay-date", request), 
			GetHeader("x-amz-pay-host", request), 
			GetHeader("x-amz-pay-region", request)
		};

		return (HeadersForOtherRequest, values);
	}
	
	private (string[] headers, string[] values) RetrieveHeadersForPostRequest(HttpRequestMessage request)
	{
		var values = new[]
		{
			"application/json", 
			"application/json", 
			GetHeader("x-amz-pay-date", request), 
			GetHeader("x-amz-pay-host", request), 
			getIdempotencyHeader(),
			GetHeader("x-amz-pay-region", request)
		};

		return (_headersForPostRequest, values);
			
		string getIdempotencyHeader()
		{
			return request.Headers.TryGetValues("x-amz-pay-idempotency-key", out var r)
				? r.First()
				: Guid.NewGuid().ToString("N");
		}
	}
	
	private string GetHeader(string header, HttpRequestMessage request)
	{
		return request.Headers.TryGetValues(header, out var r)
			? r.First()
			: string.Empty;
	}
	
	private static readonly string[] _headersForPostRequest = new[]
	{
		"accept", 
		"content-type", 
		"x-amz-pay-date", 
		"x-amz-pay-host", 
		"x-amz-pay-idempotency-key",
		"x-amz-pay-region"
	};
	
	private static string _joinedHeadersForPostRequest = string.Join(";", _headersForPostRequest);
	
	private static string[] HeadersForOtherRequest = new[]
	{
		"accept", 
		"content-type", 
		"x-amz-pay-date", 
		"x-amz-pay-host", 
		"x-amz-pay-region"
	};
	
	private static string _joinedHeadersForOtherRequest = string.Join(";", HeadersForOtherRequest);
}