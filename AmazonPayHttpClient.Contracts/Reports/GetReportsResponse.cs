using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class GetReportsResponse
{
	/// <summary>
	/// A list of report objects matching the search criteria.
	/// </summary>
	[JsonPropertyName("reports")]
	public required List<Report> Reports { get; set; } = [];

	/// <summary>
	/// Returned when the number of results exceeds pageSize. To get the next page of results, call getReports with this token as the only parameter.
	/// </summary>
	[JsonPropertyName("nextToken")]
	public string? NextToken { get; internal set; }
}