namespace AmazonPayHttpClient;

public sealed class AmazonPayIdempotencyMiddleware: DelegatingHandler
{
	private const string IdempotencyKeyHeader    = "x-amz-pay-idempotency-key";

	public AmazonPayIdempotencyMiddleware(){
		
	}
	
	public AmazonPayIdempotencyMiddleware(HttpMessageHandler innerHandler) : base(innerHandler)
	{
	}
	
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		AddIdempotencyKeyIfNotExists(request);
		return await base.SendAsync(request, cancellationToken);
	}

	private void AddIdempotencyKeyIfNotExists(HttpRequestMessage request)
	{
		if (request.Method != HttpMethod.Post || request.Headers.Contains(IdempotencyKeyHeader))
		{
			return;
		}
		
		request.Headers.Add(IdempotencyKeyHeader, Guid.NewGuid().ToString("N"));
	}
}