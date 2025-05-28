using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public class CreateReportResponse
{
     /// <summary>
     /// Report Id Identifier.
     /// </summary>
     [JsonProperty("reportId")]
     public required string ReportId { get; set; }
}