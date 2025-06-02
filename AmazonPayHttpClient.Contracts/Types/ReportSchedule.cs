using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class ReportSchedule
{
	/// <summary>
	/// The report schedule identifier.
	/// </summary>
	[JsonPropertyName("reportScheduleId")]
	public required string ReportScheduleId { get; set; }

	/// <summary>
	/// The type of the scheduled report.
	/// </summary>
	[JsonPropertyName("reportType")]
	public ReportTypes ReportType { get; set; }

	/// <summary>
	/// Frequency defining the interval between report creations.
	/// </summary>
	[JsonPropertyName("scheduleFrequency")]
	public ScheduleFrequency ScheduleFrequency { get; set; }

	/// <summary>
	/// Time when the next report will be created.
	/// </summary>
	[JsonPropertyName("nextReportCreationTime")]
	public DateTime NextReportCreationTime { get; set; }
}