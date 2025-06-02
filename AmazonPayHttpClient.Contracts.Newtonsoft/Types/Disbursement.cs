using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class Disbursement
{
	[JsonProperty("sellerId")]
	public required string SellerId { get; set; }
	
	[JsonProperty("settlementId")]
	public required string SettlementId { get; set; }
	
	[JsonProperty("AmazonDisbursementReferenceId")]
	public required string AmazonDisbursementReferenceId { get; set; }
	
	[JsonProperty("amount")]
	public decimal Amount { get; set; }
	
	[JsonProperty("currency")]
	public Currency Currency { get; set; }
	
	[JsonProperty("transactionTime")]
	public DateTime TransactionTime { get; set; }

}