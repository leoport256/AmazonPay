using AmazonPayConfigurationKeyProviders;
using AmazonPayHttpClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonPay.Samples.Dotnet8.Refit.InitCheckoutSession.Pages;

public class Pay : PageModel
{
	public string?  CheckoutSessionId { get; private set; }
	public string?  ChargePermissionId { get; private set; }
	
	public string  PublicKey { get; private set; }

	public string  MerchantId { get; private set; }

	public Pay(IAmazonConfiguration configuration, ISamplePublicKeyProvider publicKeyProvider)
	{
		PublicKey = publicKeyProvider.PublicKey;
		MerchantId = configuration.MerchantId;
	}
	
	public async Task<IActionResult> OnGetAsync([FromQuery]string? checkoutSessionId, [FromQuery]string? chargePermissionId)
	{
		CheckoutSessionId = checkoutSessionId;
		ChargePermissionId = chargePermissionId;
		return Page();
	}
}