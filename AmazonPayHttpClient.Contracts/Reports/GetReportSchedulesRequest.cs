using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class GetReportSchedulesRequest
{
     /// <summary>
     /// List of report types
     /// </summary>
     [JsonPropertyName("reportTypes")]
     public List<ReportTypes>? ReportTypes { get; set; }
}