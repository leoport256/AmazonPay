using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace AmazonPayHttpClient;

// This middleware does not need.
public class AmazonPayFixContentMiddleware: DelegatingHandler
{
	// TODO: Optiomize!
	private readonly Regex _regex = new(",?\"[a-z]([a-z]|[A-Z])+\":{}");
	private readonly Regex _regex2 = new("{,\"");

	private Regex[] Regexp => new []{ _regex, _regex2 };
	
	public AmazonPayFixContentMiddleware(){
		
	}

	
	public AmazonPayFixContentMiddleware(HttpMessageHandler innerHandler) : base(innerHandler)
	{
	}
	
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		await ProcessContent(request);
		return await base.SendAsync(request, cancellationToken);
	}

	private async Task ProcessContent(HttpRequestMessage request)
	{
		request.Content = await CreateFixedContent(request.Content);
	}

	private async Task<HttpContent?> CreateFixedContent(HttpContent? httpContent)
	{
		if (httpContent is null or not JsonContent)
		{
			return httpContent;
		}
		
		var fixedContent = await FixContent(httpContent);
		return  new StringContent(fixedContent);
	}

	private async Task<string> FixContent(HttpContent httpContent)
	{
		var content = await httpContent.ReadAsStringAsync();
		return Regexp.Aggregate(content, (s, r) => r.Replace(s, string.Empty));
	}
}