using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class GetReportSchedulesRequest
{
	/// <summary>
	/// List of report types
	/// </summary>
	[JsonProperty("reportTypes")]
	public List<ReportTypes>? ReportTypes { get; set; }
}