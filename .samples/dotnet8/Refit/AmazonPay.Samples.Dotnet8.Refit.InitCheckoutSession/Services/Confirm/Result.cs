namespace AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Confirm;

public record Result(string CheckoutSessionId,  string? ChargePermissionId);