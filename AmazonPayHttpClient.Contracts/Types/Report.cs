using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class Report
{
    /// <summary>
    /// The report identifier.
    /// </summary>
    [JsonPropertyName("reportId")]
    public required string ReportId { get; set; }

    /// <summary>
    /// The type of the report.
    /// </summary>
    [JsonPropertyName("reportType")]
    public ReportTypes ReportType { get; set; }

    /// <summary>
    /// Time from which the transactions are included in the report.
    /// </summary>
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Time to which the transactions are included in the report.
    /// </summary>
    [JsonPropertyName("endTime")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Time at which the request to create the report was received.
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// The processing status of the report.
    /// </summary>
    [JsonPropertyName("processingStatus")]
    public ProcessingStatus ProcessingStatus { get; set; }

    /// <summary>
    /// Time at which the request to create report was processed (started processing).
    /// </summary>
    [JsonPropertyName("processingStartTime")]
    public DateTime ProcessingStartTime { get; set; }


    /// <summary>
    /// Time at which the report request was completed and the report was generated.
    /// </summary>
    [JsonPropertyName("processingEndTime")]
    public DateTime ProcessingEndTime { get; set; }

    /// <summary>
    /// The report document identifier.
    /// </summary>
    [JsonPropertyName("reportDocumentId")]
    public required string ReportDocumentId { get; set; }
}