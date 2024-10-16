using System;

namespace AmazonPayHttpClient.Contracts
{
    /// <summary>
    /// Prime membership types for which the buyer is eligible.
    /// </summary>
    public enum PrimeMembershipType
    {
        NONE = 0,
        PRIME_GENERAL = 1,
        PRIME_STUDENT = 2,
        PRIME_GENERAL_US = 3
    }
}