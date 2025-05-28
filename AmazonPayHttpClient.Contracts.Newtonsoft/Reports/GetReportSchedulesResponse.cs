using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class GetReportSchedulesResponse
{
     /// <summary>
     /// A list of report schedule objects matching the search criteria.
     /// </summary>
     [JsonProperty("reportSchedules")]
     public required List<ReportSchedule> ReportSchedules { get; set; } = [];
}