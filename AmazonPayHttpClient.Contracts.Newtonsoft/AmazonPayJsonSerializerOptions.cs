using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public static class AmazonPayJsonSerializerOptions
{
	public static
		JsonSerializerSettings JsonSerializerOptions { get; } = CreateJsonSerializerOptions();

	private static 	
		JsonSerializerSettings CreateJsonSerializerOptions()
	{
		var options = new
			JsonSerializerSettings
			{
				DefaultValueHandling = DefaultValueHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver =
					new DefaultContractResolver
					{
						NamingStrategy = new CamelCaseNamingStrategy()
					},
				Formatting = Formatting.None
			};

		options.Converters.Add(new DateTimeIso8601JsonConverter());
		options.Converters.Add(new DateTimeIso8601NullableJsonConverter());
		return options;
	}
}