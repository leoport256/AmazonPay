using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CreateReportRequest
{
	/// <summary>
	/// Type of report to be created.
	/// </summary>
	[JsonProperty("reportType")]
	public ReportTypes ReportType { get; set; }

	/// <summary>
	/// Time from which the transactions are included in the report.
	/// </summary>
	[JsonProperty("startTime")]
	public DateTime? StartTime { get; set; }

	/// <summary>
	/// Time until which the transactions are included in the report.
	/// </summary>
	[JsonProperty("endTime")]
	public DateTime? EndTime { get; set; }

}