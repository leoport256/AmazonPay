using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class CreateReportScheduleResponse
{
	/// <summary>
	/// Report Schedule Id Identifier.
	/// </summary>
	[JsonPropertyName("reportScheduleId")]
	public required string ReportScheduleId { get; set; }
}