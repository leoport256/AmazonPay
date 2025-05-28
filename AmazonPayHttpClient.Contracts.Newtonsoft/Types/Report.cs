using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class Report
{
    /// <summary>
    /// The report identifier.
    /// </summary>
    [JsonProperty("reportId")]
    public required string ReportId { get; set; }

    /// <summary>
    /// The type of the report.
    /// </summary>
    [JsonProperty("reportType")]
    public ReportTypes ReportType { get; set; }

    /// <summary>
    /// Time from which the transactions are included in the report.
    /// </summary>
    [JsonProperty("startTime")]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Time to which the transactions are included in the report.
    /// </summary>
    [JsonProperty("endTime")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Time at which the request to create the report was received.
    /// </summary>
    [JsonProperty("createdTime")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// The processing status of the report.
    /// </summary>
    [JsonProperty("processingStatus")]
    public ProcessingStatus ProcessingStatus { get; set; }

    /// <summary>
    /// Time at which the request to create report was processed (started processing).
    /// </summary>
    [JsonProperty("processingStartTime")]
    public DateTime ProcessingStartTime { get; set; }


    /// <summary>
    /// Time at which the report request was completed and the report was generated.
    /// </summary>
    [JsonProperty("processingEndTime")]
    public DateTime ProcessingEndTime { get; set; }

    /// <summary>
    /// The report document identifier.
    /// </summary>
    [JsonProperty("reportDocumentId")]
    public required string ReportDocumentId { get; set; }
}