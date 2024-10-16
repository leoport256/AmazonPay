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

		var builder = new SignatureBuilder(request.RequestUri, 
			content, 
			retrieveAllRequestHeaders(), 
			_hash, 
			_signer,
			request.Method.Method);
		
		var (signBytes, signedHeaders) = await builder.Build();
		var signature = Convert.ToBase64String(signBytes);
		return (signature, signedHeaders);

		IEnumerable<KeyValuePair<string, IEnumerable<string>>> retrieveAllRequestHeaders()
		{
			return concatWithIdempotencyHeader([
				new("accept", getHeader("accept")),
				new("content-type", new[] { "application/json" }),
				new("x-amz-pay-region", getHeader("x-amz-pay-region")),
				new("x-amz-pay-date", getHeader("x-amz-pay-date")),
				new("x-amz-pay-host", getHeader("x-amz-pay-host"))
			]);

			IEnumerable<string> getHeader(string header)
			{
				return request.Headers.TryGetValues(header, out var r)
					? r
					: Array.Empty<string>().AsEnumerable();
			}
			
			IEnumerable<KeyValuePair<string, IEnumerable<string>>> concatWithIdempotencyHeader(KeyValuePair<string, IEnumerable<string>>[] headers)
			{
				if(request.Method != HttpMethod.Post)
					return headers;

				return request.Headers.TryGetValues("x-amz-pay-idempotency-key", out var r)
					? headers.Concat(new[] { new KeyValuePair<string, IEnumerable<string>>("x-amz-pay-idempotency-key", r) })
					: throw new InvalidOperationException("No idempotency key. Can not post request.");
			}
		}
	}
}