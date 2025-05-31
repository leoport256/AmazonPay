using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class GetReportSchedulesResponse
{
     /// <summary>
     /// A list of report schedule objects matching the search criteria.
     /// </summary>
     [JsonPropertyName("reportSchedules")]
     public required List<ReportSchedule> ReportSchedules { get; set; } = [];
}