using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class CreateReportScheduleResponse
{
     /// <summary>
     /// Report Schedule Id Identifier.
     /// </summary>
     [JsonProperty("reportScheduleId")]
     public required string ReportScheduleId { get; set; }
}