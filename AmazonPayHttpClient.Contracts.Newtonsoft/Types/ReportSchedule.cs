using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class ReportSchedule
{
    /// <summary>
    /// The report schedule identifier.
    /// </summary>
    [JsonProperty("reportScheduleId")]
    public required string ReportScheduleId { get; set; }

    /// <summary>
    /// The type of the scheduled report.
    /// </summary>
    [JsonProperty("reportType")]
    public ReportTypes ReportType { get; set; }

    /// <summary>
    /// Frequency defining the interval between report creations.
    /// </summary>
    [JsonProperty("scheduleFrequency")]
    public ScheduleFrequency ScheduleFrequency { get; set; }

    /// <summary>
    /// Time when the next report will be created.
    /// </summary>
    [JsonProperty("nextReportCreationTime")]
    public DateTime NextReportCreationTime { get; set; }
}