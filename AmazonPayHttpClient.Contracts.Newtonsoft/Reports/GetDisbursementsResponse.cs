﻿using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class GetDisbursementsResponse
{
	[JsonProperty("disbursements")]
	public required List<Disbursement> Disbursements { get; set; } = [];
	
	[JsonProperty("nextToken")]
	public string? NextToken { get; set; }

}