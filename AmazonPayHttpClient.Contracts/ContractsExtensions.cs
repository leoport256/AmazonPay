namespace AmazonPayHttpClient.Contracts;

public static  class ContractsExtensions
{
    public static InnerCountryAddressRestriction AddCountryRestriction(this AddressRestrictions source,
        string countryCode)
    {
        source.Restrictions.Add(countryCode, new Restriction());
        return new InnerCountryAddressRestriction(countryCode, source);
    }
}