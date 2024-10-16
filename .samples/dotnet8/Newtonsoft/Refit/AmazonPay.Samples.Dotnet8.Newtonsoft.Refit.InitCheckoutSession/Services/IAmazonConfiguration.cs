namespace AmazonPay.Samples.Dotnet8.Newtonsoft.Refit.InitCheckoutSession;

public interface IAmazonConfiguration
{
	string StoreId { get; }
	
	string MerchantId { get; }
}

internal sealed  class AmazonConfiguration: IAmazonConfiguration
{
	public string StoreId { get; }
	public string MerchantId { get; }

	public AmazonConfiguration(IConfiguration configuration)
	{
		StoreId = configuration.GetValue<string>("storeId") ??
				throw new InvalidOperationException("storeId configuration property should be set");
		
		MerchantId = configuration.GetValue<string>("merchantId") ??
					throw new InvalidOperationException("merchantId configuration property should be set");

	}
}