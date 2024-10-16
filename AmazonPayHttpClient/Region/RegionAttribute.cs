namespace AmazonPayHttpClient
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)] 
    public class RegionAttribute : Attribute
    {
        public RegionAttribute(string shortform, string domain, string url)
        {
            ShortForm = shortform;
            Domain = domain;
            Url = url;
        }

        public string ShortForm { get; }

        public string Domain { get; }

        public string Url { get; set; }
    }
}
