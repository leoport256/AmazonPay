using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class CreateReportRequest
{
     /// <summary>
     /// Type of report to be created.
     /// </summary>
     [JsonPropertyName("reportType")]
     public ReportTypes ReportType { get; set; }

     /// <summary>
     /// Time from which the transactions are included in the report.
     /// </summary>
     [JsonPropertyName("startTime")]
     public DateTime StartTime { get; set; }

     /// <summary>
     /// Time until which the transactions are included in the report.
     /// </summary>
     [JsonPropertyName("endTime")]
     public DateTime EndTime { get; set; }

}