using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class Disbursement
{
	[JsonPropertyName("sellerId")]
	public required string SellerId { get; set; }
	
	[JsonPropertyName("settlementId")]
	public required string SettlementId { get; set; }
	
	[JsonPropertyName("AmazonDisbursementReferenceId")]
	public required string AmazonDisbursementReferenceId { get; set; }
	
	[JsonPropertyName("amount")]
	public decimal Amount { get; set; }
	
	[JsonPropertyName("currency")]
	public Currency Currency { get; set; }
	
	[JsonPropertyName("transactionTime")]
	public DateTime TransactionTime { get; set; }

}