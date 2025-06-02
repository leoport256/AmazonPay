using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class GetReportDocumentResponse
{
	/// <summary>
	/// Report Document Id Identifier.
	/// </summary>
	[JsonPropertyName("reportDocumentId")]
	public required string ReportDocumentId { get; set; }

	/// <summary>
	/// URL Identifier.
	/// </summary>
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	/// <summary>
	/// Compression Algorithm Identifier. ( At this time always "N/A")
	/// </summary>
	[JsonPropertyName("compressionAlgorithm")]
	public string? CompressionAlgorithm { get; set; }
}