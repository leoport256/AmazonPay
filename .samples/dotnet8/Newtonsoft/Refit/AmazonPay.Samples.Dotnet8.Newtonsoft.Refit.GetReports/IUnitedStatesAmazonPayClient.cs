using AmazonPayHttpClient.Contracts.Newtonsoft;
using AmazonPayHttpClient.Refit.Newtonsoft;
using Refit;

namespace AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.GetReports;

public interface IUnitedStatesAmazonPayClient: IAmazonPayClient
{
	[Get("/v2/reports")]
	Task<ApiResponse<GetReportsResponse>> GetReportsWithFailSignature(
		[Query(CollectionFormat.Csv)][AliasAs("processingStatuses")]ProcessingStatus[]? processingStatuses = null,

		[Query(Format = AmazonDateTimeFormat.Format)][AliasAs("createdSince")]DateTime? createdSince = null, 
		[Query(Format = AmazonDateTimeFormat.Format)][AliasAs("createdUntil")]DateTime? createdUntil = null,
		[Query][AliasAs("nextToken")]string? nextToken = null,
		[Query][AliasAs("pageSize")]int pageSize = 10, 
		[Query(CollectionFormat.Csv)][AliasAs("reportTypes")]ReportTypes[]? reportTypes = null);

}