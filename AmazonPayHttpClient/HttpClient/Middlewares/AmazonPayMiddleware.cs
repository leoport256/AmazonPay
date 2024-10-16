using System.Globalization;

namespace AmazonPayHttpClient;

public class AmazonPayMiddleware: DelegatingHandler
{
	private const string SdkVersion = "2.6.0.0";
	private const string SdkName    = "amazon-pay-api-sdk-dotnet";

	public AmazonPayMiddleware(){
		
	}
	
	public AmazonPayMiddleware(HttpMessageHandler innerHandler) : base(innerHandler)
	{
	}
	
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		PrepareAmazonPayHeaders(request);
		return await base.SendAsync(request, cancellationToken);
	}

	private void PrepareAmazonPayHeaders(HttpRequestMessage request)
	{
		RemoveBannedHeader(request);
		AddAmazonPayHeaders(request);
	}

	private void AddAmazonPayHeaders(HttpRequestMessage request)
	{
		request.Headers.Add("accept", "application/json");
		request.Headers.Add("user-agent", UserAgent);
		request.Content!.Headers.Add("content-type", "application/json");

		addIfNotExists("x-amz-pay-region", "na");
		addIfNotExists("x-amz-pay-date", GetFormattedTimestamp);
		addIfNotExists("x-amz-pay-host", request.RequestUri!.Host);
		
		void addIfNotExists(string header, string value)
		{
			if (!request.Headers.Contains(header))
			{
				request.Headers.Add(header, value);
			}
		}
	}

	private void RemoveBannedHeader(HttpRequestMessage request)
	{
		request.Headers.Remove("accept");
		request.Headers.Remove("user-agent");
		
		// It is necessary tp send content-type header with get request. (But must be checked may be not)
		request.Content?.Headers.Remove("content-type");
	}

	private string GetFormattedTimestamp => 
		DateTime.UtcNow.ToString("yyyyMMdd\\THHmmss\\Z",
			CultureInfo.InvariantCulture);

	
	private string UserAgent =>  $"{SdkName}/{SdkVersion} ({Environment.OSVersion.Platform})";
}