namespace AmazonPayHttpClient.Contracts
{
    /// <summary>
    /// Type of Business.
    /// </summary>
   // [JsonConverter(typeof(StringEnumConverter))]
    public enum BusinessType
    {
        /// <summary>
        /// Corporate Entity
        /// </summary>
        CORPORATE,

        /// <summary>
        /// Indiviual Entity/ Sole Propeitor
        /// </summary>
        INDIVIDUAL
    }
}