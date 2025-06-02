using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class GetReportDocumentResponse
{
	/// <summary>
	/// Report Document Id Identifier.
	/// </summary>
	[JsonProperty("reportDocumentId")]
	public required string ReportDocumentId { get; set; }

	/// <summary>
	/// URL Identifier.
	/// </summary>
	[JsonProperty("url")]
	public string? Url { get; set; }

	/// <summary>
	/// Compression Algorithm Identifier. ( At this time always "N/A")
	/// </summary>
	[JsonProperty("compressionAlgorithm")]
	public string? CompressionAlgorithm { get; set; }
}