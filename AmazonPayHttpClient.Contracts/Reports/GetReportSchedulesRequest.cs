using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class GetReportSchedulesRequest
{
     /// <summary>
     /// List of report types
     /// </summary>
     [JsonPropertyName("reportTypes")]
     public List<ReportTypes>? ReportTypes { get; set; }
}