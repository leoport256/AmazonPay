namespace AmazonPayHttpClient
{
    public enum Region
    {
        /// <summary>
        /// United Kingdom (GBP) and all countries in the EUR region.
        /// </summary>
        [Region(shortform: "eu", domain: "eu", url: "https://pay-api.amazon.eu")]
        Europe,

        /// <summary>
        /// Japan (JPY)
        /// </summary>
        [Region(shortform: "jp", domain: "jp", url: "https://pay-api.amazon.jp")]
        Japan,

        /// <summary>
        /// United States (USD)
        /// </summary>
        [Region(shortform: "na", domain: "com", url: "https://pay-api.amazon.com")]
        UnitedStates
    }
}
