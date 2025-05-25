using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class GetReportsRequest
{
     public GetReportsRequest(List<ReportTypes>? reportTypes = null, List<ProcessingStatus>? processingStatuses = null, DateTime? createdSince = null, DateTime? createdUntil = null, int pageSize = 10, string? nextToken = null)
     {
          ReportTypes = reportTypes;
          ProcessingStatuses = processingStatuses;
          CreatedSince = createdSince ?? DateTime.UtcNow.AddDays(-90);
          CreatedUntil = createdUntil ?? DateTime.UtcNow;
          PageSize = pageSize;
          NextToken = nextToken;
     }

     /// <summary>
     /// List of types of reports requested.
     /// </summary>
     [JsonPropertyName("reportTypes")]
     public List<ReportTypes>? ReportTypes { get; set; }

     /// <summary>
     /// A list of processing statuses used to filter reports.
     /// </summary>
     [JsonPropertyName("processingStatuses")]
     public List<ProcessingStatus>? ProcessingStatuses { get; set; }

     /// <summary>
     /// The earliest report creation date and time for reports to include in the response, in ISO 8601 date time format. Reports are retained for a maximum of 90 days.
     /// </summary>
     [JsonPropertyName("createdSince")]
     public DateTime? CreatedSince { get; set; }

     /// <summary>
     /// The latest report creation date and time for reports to include in the response, in ISO 8601 date time format. Reports are retained for a maximum of 90 days.
     /// </summary>
     [JsonPropertyName("createdUntil")]
     public DateTime? CreatedUntil { get; set; }
          
     /// <summary>
     /// The number of reports per page to return.
     /// </summary>
     [JsonPropertyName("pageSize")]
     public int PageSize { get; set; }

     /// <summary>
     /// A string token returned in the response to your previous request. nextToken is returned when the number of results exceeds the specified pageSize value. To get the next page of results, call the getReports operation and include this token as the only parameter. Specifying nextToken with any other parameters will cause the request to fail.
     /// </summary>
     [JsonPropertyName("nextToken")]
     public string? NextToken { get; set; }
}