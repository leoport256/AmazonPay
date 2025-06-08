namespace AmazonPayHttpClient;

public sealed class AmazonPayPrepareContentMiddleware: DelegatingHandler
{
	public AmazonPayPrepareContentMiddleware(){
		
	}
	
	public AmazonPayPrepareContentMiddleware(HttpMessageHandler innerHandler) : base(innerHandler)
	{
	}
	
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		request.Content ??= new StringContent(string.Empty);
		return await base.SendAsync(request, cancellationToken);
	}
}