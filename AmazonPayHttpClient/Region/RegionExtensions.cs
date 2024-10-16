namespace AmazonPayHttpClient
{
    public static class RegionExtensions
    {
        private static RegionAttribute GetRegionAttribute(Region region)
        {
            var enumType = typeof(Region);
            var memberInfos = enumType.GetMember(region.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo?.GetCustomAttributes(typeof(RegionAttribute), false);
            var attribute = valueAttributes?.FirstOrDefault() as RegionAttribute;

            return attribute ?? 
                   throw new InvalidOperationException($"Can not find attribute for region {region}");
        }

        /// <summary>
        /// Returns the Amazon Pay defined shortform for the region, e.g. 'eu' for 'Europe'.
        /// </summary>
        internal static string ToShortForm(this Region region)
        {
            var attribute = GetRegionAttribute(region);
            return attribute.ShortForm;
        }

        /// <summary>
        /// Returns the API endpoint domain for the given region.
        /// </summary>
        internal static string ToDomain(this Region region)
        {
            var attribute = GetRegionAttribute(region);
            return attribute.Domain;
        }
        
        /// <summary>
        /// Returns the API endpoint domain for the given region.
        /// </summary>
        internal static string ToUrl(this Region region)
        {
            var attribute = GetRegionAttribute(region);
            return attribute.Url;
        }
    }

}
