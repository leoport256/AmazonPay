using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace AmazonPayHttpClient;

public sealed class AmazonPaySignMiddleware<TPrivateKeyProvider, TPublicKeyProvider>: DelegatingHandler
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
		var authorizationBuilder = new StringBuilder(512)
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

		var (builder, signedHeaders) = request.Method == HttpMethod.Post
			? CreateSignatureBuilderForPost(request.Headers, request.RequestUri, content)
			: CreateSignatureBuilderForOther(request.Headers, request.RequestUri, content, request.Method);
		
		var signBytes = builder.Build();
		var signature = Convert.ToBase64String(signBytes);
		return (signature, signedHeaders);
	}

	private (SignatureBuilder, string) CreateSignatureBuilderForPost(HttpHeaders headers,  Uri?  uri, string? content)
	{
		var headersValues = RetrieveHeadersForPostRequest(headers);
		return (new SignatureBuilder(uri, 
			content, 
			SignatureHeaders.HeadersForPostRequest,
			SignatureHeaders.JoinedHeadersForPostRequest,
			headersValues,
			_hash, 
			_signer,
			HttpMethod.Post.Method), SignatureHeaders.JoinedHeadersForPostRequest);
	}

	private (SignatureBuilder, string) CreateSignatureBuilderForOther(HttpHeaders headers, Uri? uri,
		string? content, HttpMethod method)
	{
		var  headersValues = RetrieveHeaders(headers);
		return (new SignatureBuilder(uri,
			content,
			SignatureHeaders.HeadersForOtherRequest,
			SignatureHeaders.JoinedHeadersForOtherRequest,
			headersValues,
			_hash,
			_signer,
			method.Method), SignatureHeaders.JoinedHeadersForOtherRequest);
	}

	private string[] RetrieveHeaders(HttpHeaders headers)
	{
		var values = new[]
		{
			"application/json", 
			"application/json", 
			GetHeader("x-amz-pay-date", headers), 
			GetHeader("x-amz-pay-host", headers), 
			GetHeader("x-amz-pay-region", headers)
		};

		return values;
	}
	
	private string[] RetrieveHeadersForPostRequest(HttpHeaders headers)
	{
		var values = new[]
		{
			"application/json", 
			"application/json", 
			GetHeader("x-amz-pay-date", headers), 
			GetHeader("x-amz-pay-host", headers), 
			getIdempotencyHeader(),
			GetHeader("x-amz-pay-region", headers)
		};

		return values;
			
		string getIdempotencyHeader()
		{
			return headers.TryGetValues("x-amz-pay-idempotency-key", out var r)
				? r.First()
				: Guid.NewGuid().ToString("N");
		}
	}
	
	private string GetHeader(string header, HttpHeaders headers)
	{
		return headers.TryGetValues(header, out var r)
			? r.First()
			: string.Empty;
	}
	

}

internal static class SignatureHeaders
{
	public static readonly string[] HeadersForPostRequest = new[]
	{
		"accept", 
		"content-type", 
		"x-amz-pay-date", 
		"x-amz-pay-host", 
		"x-amz-pay-idempotency-key",
		"x-amz-pay-region"
	};
	
	public static readonly string JoinedHeadersForPostRequest = string.Join(";", HeadersForPostRequest);
	
	public static readonly string[] HeadersForOtherRequest = new[]
	{
		"accept", 
		"content-type", 
		"x-amz-pay-date", 
		"x-amz-pay-host", 
		"x-amz-pay-region"
	};
	
	public static readonly string JoinedHeadersForOtherRequest = string.Join(";", HeadersForOtherRequest);
}