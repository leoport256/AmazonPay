using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class CreateReportScheduleRequest
{
    /// <summary>
    /// Type of the report for the schedule
    /// </summary>
    [JsonPropertyName("reportType")]
    public ReportTypes ReportType { get; set; }

    /// <summary>
    /// Frequency in which the report shall be created.
    /// </summary>
    [JsonPropertyName("scheduleFrequency")]
    public ScheduleFrequency ScheduleFrequency { get; set; }

    /// <summary>
    /// ISO 8601 time defining the next report creation time.
    /// </summary>
    [JsonPropertyName("nextReportCreationTime")]
    public DateTime NextReportCreationTime { get; set; }

    /// <summary>
    /// If true deletes an existing report schedule for the given report type. The API returns an array, if a schedule for the given report type already exists and set to false.
    /// </summary>
    [JsonPropertyName("deleteExistingSchedule")]
    public bool DeleteExistingSchedule { get; set; }
}