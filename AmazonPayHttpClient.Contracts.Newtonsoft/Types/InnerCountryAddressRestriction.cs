namespace AmazonPayHttpClient.Contracts.Newtonsoft
{
    /// <summary>
    /// An address restriction inside a specific country such as a state, region or postal code.
    /// </summary>
    public sealed class InnerCountryAddressRestriction
    {
        private readonly AddressRestrictions _parent;
        private readonly string _countryCode;

        internal InnerCountryAddressRestriction(string countryCode, AddressRestrictions parent)
        {
            _parent = parent;
            _countryCode = countryCode;
        }

        /// <summary>
        /// Add restriction for a state or region of this country.
        /// </summary>
        /// <param name="stateOrRegion">State or region code, for instance CA for California.</param>
        /// <returns>The same InnerCountryAddressRestriction object so that additional state, region or postal code can be added.</returns>
        public InnerCountryAddressRestriction AddStateOrRegionRestriction(string stateOrRegion)
        {
            Restriction existingRestriction = GetExistingRestriction();

            existingRestriction.StatesOrRegions.Add(stateOrRegion);

            return this;
        }

        /// <summary>
        /// Add restriction for a ZIP code of this country.
        /// </summary>
        /// <param name="zipCode">ZIP code, for instance 12345.</param>
        /// <returns>The same InnerCountryAddressRestriction object so that additional state, region or postal code can be added.</returns>
        public InnerCountryAddressRestriction AddZipCodesRestriction(string zipCode)
        {
            Restriction existingRestriction = GetExistingRestriction();

            existingRestriction.ZipCodes.Add(zipCode);

            return this;
        }

        private Restriction GetExistingRestriction()
        {
            if (_parent.Restrictions.TryGetValue(_countryCode, out var restriction))
            {
                return restriction;
            }

            var newRestriction = new Restriction();
            _parent.Restrictions.TryAdd(_countryCode, newRestriction);

            return newRestriction;
        }
    }
}
