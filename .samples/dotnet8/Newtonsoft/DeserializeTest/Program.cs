// See https://aka.ms/new-console-template for more information

using AmazonPayHttpClient.Contracts.Newtonsoft;
using Newtonsoft.Json;


var str = 
	"""
		{"creationTimestamp":"20241012T203702Z"}
	""";

try
{
	var ttt = JsonConvert.DeserializeObject<TestClass>(str, AmazonPayJsonSerializerOptions.JsonSerializerOptions);

}
catch (Exception e)
{
	Console.WriteLine(e);
	throw;
}
Console.WriteLine("Hello, World!");

public class TestClass
{
	[JsonProperty("creationTimestamp")]
	public DateTime ChargeAmount { get; set; }
}