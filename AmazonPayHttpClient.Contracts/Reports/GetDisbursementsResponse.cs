using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public class GetDisbursementsResponse
{
	[JsonPropertyName("disbursements")]
	public required List<Disbursement> Disbursements { get; set; } = [];
	
	[JsonPropertyName("nextToken")]
	public string? NextToken { get; set; }

}