﻿using AmazonPayHttpClient.Contracts;
using Refit;

namespace AmazonPayHttpClient.Refit;

[Headers("Content-Type: application/json", "Accept: application/json")]
public interface IAmazonPayClient
{
	[Get("/v2/checkoutSessions/{checkoutSessionId}")]
	Task<ApiResponse<CheckoutSession>> GetCheckoutSession(string checkoutSessionId, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);

	[Patch("/v2/checkoutSessions/{checkoutSessionId}")]
	Task<ApiResponse<CheckoutSession>> UpdateCheckoutSession(
		string checkoutSessionId,
		UpdateCheckoutSessionRequest request);
	

	[Post("/v2/checkoutSessions/{checkoutSessionId}/complete")]
	Task<ApiResponse<CheckoutSession>> CompleteCheckoutSession(
		string checkoutSessionId,
		CompleteCheckoutSessionRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);
	
		
	[Post("/v2/checkoutSessions/{checkoutSessionId}/finalize")]
	Task<ApiResponse<CheckoutSession>> FinalizeCheckoutSessionRequest(string checkoutSessionId, FinalizeCheckoutSessionRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);	


	
	[Get("/v2/chargePermissions/{chargePermissionId}")]
	Task<ApiResponse<ChargePermissionResponse>> GetChargePermission(string chargePermissionId);
	
	[Delete("/v2/chargePermissions/{chargePermissionId}/close")]
	Task<ApiResponse<ChargePermissionResponse>> CloseChargePermission(
		string chargePermissionId,
		[Body]CloseChargePermissionRequest request
	);
	
	[Get("/v2/charges/{chargeId}")]
	Task<ApiResponse<Charge>> GetCharge(string chargeId);
	
	[Post("/v2/charges/")]
	Task<ApiResponse<Charge>> CreateCharge(
		CreateChargeRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);
	
	[Post("/v2/charges/{chargeId}/capture")]
	Task<ApiResponse<Charge>> CaptureCharge(
		string chargeId,
		CaptureChargeRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);
	
	[Delete("/v2/charges/{chargeId}/cancel")]
	Task<ApiResponse<Charge>> CancelCharge(
		string chargeId,
		[Body]CancelChargeRequest request
		);
	
	[Post("/v2/refunds")]
	Task<ApiResponse<Refund>> CreateRefund(
		CreateRefundRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);	

	[Get("/v2/refunds/{refundId}")]
	Task<ApiResponse<Refund>> GetRefund(string refundId);	

	[Post("/v2/deliveryTrackers")]
	Task<ApiResponse<DeliveryTrackerResponse>> CreateDeliveryTracker(DeliveryTrackerRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);
	
	
	[Get("/v2/reports")]
	Task<ApiResponse<GetReportsResponse>> GetReports(
		[Query(Format = AmazonDateTimeFormat.Format)][AliasAs("createdSince")]DateTime? createdSince = null, 
		[Query(Format = AmazonDateTimeFormat.Format)][AliasAs("createdUntil")]DateTime? createdUntil = null,
		[Query][AliasAs("nextToken")]string? nextToken = null,
		[Query][AliasAs("pageSize")]int pageSize = 10, 
		[Query(CollectionFormat.Csv)][AliasAs("processingStatuses")]ProcessingStatus[]? processingStatuses = null,
		[Query(CollectionFormat.Csv)][AliasAs("reportTypes")]ReportTypes[]? reportTypes = null);

	[Get("/v2/report-schedules")]
	Task<ApiResponse<GetReportSchedulesResponse>> GetReportSchedules(
		[Query(CollectionFormat.Csv)] [AliasAs("reportTypes")] ReportTypes[]? reportTypes = null);
	
	[Get("/v2/disbursements")]
	Task<ApiResponse<GetDisbursementsResponse>> GetDisbursements(
		[Query(Format = AmazonDateTimeFormat.Format)][AliasAs("endTime")]DateTime? endTime = null,
		[Query][AliasAs("nextToken")]string? nextToken = null,
		[Query][AliasAs("pageSize")]int pageSize = 10, 
		[Query(Format = AmazonDateTimeFormat.Format)][AliasAs("startTime")]DateTime? startTime = null
		);	

	
	[Get("/v2/report/{id}")]
	Task<ApiResponse<Report>> GetReport(string id);	

	[Post("/v2/reports")]
	Task<ApiResponse<CreateReportResponse>> CreateReport(CreateReportRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);	

	
	[Get("/v2/report-documents/{id}")]
	Task<ApiResponse<GetReportDocumentResponse>> GetReportDocument(string id);	
	
	[Get("/v2/report-schedules/{id}")]
	Task<ApiResponse<ReportSchedule>> GetReportSchedule(string id);	

	[Post("/v2/report-schedules")]
	Task<ApiResponse<CreateReportScheduleResponse>> CreateReportSchedule(CreateReportScheduleRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);	

	[Delete("/v2/report-schedules/{id}")]
	Task<ApiResponse<CancelReportScheduleResponse>> CancelReportSchedule(string id);	

	
	[Post("/v2/merchantAccounts")]
	Task<ApiResponse<RegisterAmazonPayAccountResponse>> RegisterAmazonPayAccount(RegisterAmazonPayAccountRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);	
	
	[Patch("/v2/merchantAccounts/{merchantAccountId}")]
	Task<ApiResponse<UpdateAmazonPayAccountResponse>> UpdateAmazonPayAccount(string merchantAccountId, UpdateAmazonPayAccountRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);	

	[Delete("/v2/merchantAccounts/{merchantAccountId}")]
	Task<ApiResponse<DeleteAmazonPayAccountResponse>> DeleteAmazonPayAccount(string merchantAccountId, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);
	
	/// <summary>
	/// Get buyer details.
	/// </summary>
	/// <param name="buyerToken">Token used to retrieve buyer details. This value is appended as a query parameter to signInReturnUrl.</param>
	/// <returns>Object with buyer details.</returns>
	/// <remarks>
	/// Get Buyer will only return buyerId by default. You must explicitly request access to additional buyer details using the button signInScopes parameter.
	/// Amazon Pay will only provide the token required to retrieve buyer details after the buyer signs in. It will be appended to the signInReturnUrl as a query parameter and expires after 24 hours.
	/// </remarks>
	[Get("/v2/buyers/{buyerToken}")]
	Task<ApiResponse<BuyerResponse>> GetBuyer(string buyerToken);
}
