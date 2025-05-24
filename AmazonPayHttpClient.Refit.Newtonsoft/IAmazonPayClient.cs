using AmazonPayHttpClient.Contracts.Newtonsoft;
using Refit;

namespace AmazonPayHttpClient.Refit.Newtonsoft;

[Headers("Content-Type: application/json", "Accept: application/json")]
public interface IAmazonPayClient
{
	[Get("/v2/checkoutSessions/{checkoutSessionId}")]
	Task<ApiResponse<CheckoutSessionResponse>> GetCheckoutSession(string checkoutSessionId, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);

	[Patch("/v2/checkoutSessions/{checkoutSessionId}")]
	Task<ApiResponse<CheckoutSessionResponse>> UpdateCheckoutSession(
		string checkoutSessionId,
		UpdateCheckoutSessionRequest request);
	

	[Post("/v2/checkoutSessions/{checkoutSessionId}/complete")]
	Task<ApiResponse<CheckoutSessionResponse>> CompleteCheckoutSession(
		string checkoutSessionId,
		CompleteCheckoutSessionRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);
	
	[Get("/v2/chargePermissions/{chargePermissionId}")]
	Task<ApiResponse<ChargePermissionResponse>> GetChargePermission(string chargePermissionId);
	
	[Delete("/v2/chargePermissions/{chargePermissionId}/close")]
	Task<ApiResponse<ChargePermissionResponse>> CloseChargePermission(
		string chargePermissionId,
		[Body]CloseChargePermissionRequest request
	);
	
	[Get("/v2/charges/{chargeId}")]
	Task<ApiResponse<ChargeResponse>> GetCharge(string chargeId);
	
	[Post("/v2/charges/")]
	Task<ApiResponse<ChargeResponse>> CreateCharge(
		CreateChargeRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);
	
	[Post("/v2/charges/{chargeId}/capture")]
	Task<ApiResponse<ChargeResponse>> CaptureCharge(
		string chargeId,
		CaptureChargeRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);
	
	[Delete("/v2/charges/{chargeId}/cancel")]
	Task<ApiResponse<ChargeResponse>> CancelCharge(
		string chargeId,
		[Body]CancelChargeRequest request
		);
	
	[Post("/v2/refunds")]
	Task<ApiResponse<RefundResponse>> CreateRefund(
		CreateRefundRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null, 
		[Header("x-amz-pay-simulation-code")]string? sandboxSimulationCode = null);	

	[Get("/v2/refunds/{refundId}")]
	Task<ApiResponse<RefundResponse>> GetRefund(string refundId);	
	
	[Post("/v2/deliveryTrackers")]
	Task<ApiResponse<DeliveryTrackerResponse>> CreateDeliveryTracker(DeliveryTrackerRequest request, [Header("x-amz-pay-idempotency-key")]string? idempotencyKey = null);
}
