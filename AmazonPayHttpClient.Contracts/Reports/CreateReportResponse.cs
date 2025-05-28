using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class CreateReportResponse
{
     /// <summary>
     /// Report Id Identifier.
     /// </summary>
     [JsonPropertyName("reportId")]
     public required string ReportId { get; set; }
}