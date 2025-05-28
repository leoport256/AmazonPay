using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class CreateReportScheduleRequest
{
    /// <summary>
    /// Type of the report for the schedule
    /// </summary>
    [JsonProperty("reportType")]
    public ReportTypes ReportType { get; set; }

    /// <summary>
    /// Frequency in which the report shall be created.
    /// </summary>
    [JsonProperty("scheduleFrequency")]
    public ScheduleFrequency ScheduleFrequency { get; set; }

    /// <summary>
    /// ISO 8601 time defining the next report creation time.
    /// </summary>
    [JsonProperty("nextReportCreationTime")]
    public DateTime NextReportCreationTime { get; set; }

    /// <summary>
    /// If true deletes an existing report schedule for the given report type. The API returns an array, if a schedule for the given report type already exists and set to false.
    /// </summary>
    [JsonProperty("deleteExistingSchedule")]
    public bool DeleteExistingSchedule { get; set; }
}